using System;
using System.Buffers;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.IO.Pipelines;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using MeteoSharp.Bulletins;
using MeteoSharp.Time;

namespace MeteoSharp.Readers
{
    public class WmoBulletinReader
    {
        private const byte StarMarker = (byte) '*';
        private const byte HashMarker = (byte) '#';

        private static readonly ReadOnlyMemory<byte> StarMarkers = new [] { StarMarker, StarMarker, StarMarker, StarMarker };
        private static readonly ReadOnlyMemory<byte> HashMarkers = new [] { HashMarker, HashMarker, HashMarker, HashMarker };

        public WmoBulletinReader()
        {
        }

        public IAsyncEnumerable<WmoBulletin> Read(Stream stream)
        {
            var pipe = new Pipe(new PipeOptions(useSynchronizationContext: false));
            FillPipeAsync(stream, pipe.Writer);
            return ReadPipeAsync(pipe.Reader);
        }

        private async void FillPipeAsync(Stream stream, PipeWriter writer)
        {
            const int bufferSize = 512;

#if NETSTANDARD2_0
            var buffer = ArrayPool<byte>.Shared.Rent(bufferSize);
#endif
            try
            {
                while (true)
                {
#if NETSTANDARD2_0
                    int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length).ConfigureAwait(false);
                    if (bytesRead == 0)
                        break;

                    var result = await writer.WriteAsync(new ReadOnlyMemory<byte>(buffer, 0, bytesRead)).ConfigureAwait(false);
#else
                    var buffer = writer.GetMemory(bufferSize);
                    int bytesRead = await stream.ReadAsync(buffer).ConfigureAwait(false);

                    if (bytesRead == 0)
                        break;

                    writer.Advance(bytesRead);
                    var result = await writer.FlushAsync().ConfigureAwait(false);
#endif
                    if (result.IsCompleted)
                        break;
                }

                writer.Complete();
            }
            catch (Exception ex)
            {
                writer.Complete(ex);
            }
#if NETSTANDARD2_0
            finally
            {
                ArrayPool<byte>.Shared.Return(buffer);
            }
#endif
        }

        private async IAsyncEnumerable<WmoBulletin> ReadPipeAsync(PipeReader reader, bool? hasSupplementaryIdentificationLine = null)
        {
            var builders = new Dictionary<byte[], BulletingBuilder>(new ByteArrayEqualityComparer());
            BulletingBuilder builder = null;

            while (true)
            {
                var part = Part.None;
                byte marker = 0;
                int blockLength = 0;
                int totalLength = 0;
                SequencePosition? bulletinStart = null;

                var result = await reader.ReadAsync();
                if (result.IsCanceled)
                    break;

                var buffer = result.Buffer;
                var (consumed, examined, bulletinFinished) = ProcessSequence(buffer);
                reader.AdvanceTo(consumed, examined);
                if (bulletinFinished)
                {
                    if (!builder.IsMultipart || builder.Part == BulletinPart.Last)
                    {
                        yield return builder.Build();
                        builder.Reset();
                    }

                    continue;
                }

                if (result.IsCompleted)
                    break;


                (SequencePosition consumed, SequencePosition examined, bool bulletinFinished) ProcessSequence(
                    in ReadOnlySequence<byte> sequence)
                {
                    var data = sequence;
                    var bulletinFinished = false;
                    while (!data.IsEmpty)
                    {
                        switch (part)
                        {
                            case Part.None:
                                ProcessPartNone(ref data);
                                break;
                            case Part.FlagFieldSeparator:
                                if (!ProcessFlagFieldSeparator(ref data))
                                    goto END;
                                break;
                            case Part.BulletinHeading:
                                if (!ProcessBulletinHeading(ref data))
                                    goto END;
                                break;
                            case Part.SupplementaryIdentificationLine:
                                if (!ProcessSupplementaryIdentificationLine(ref data))
                                    goto END;
                                break;
                            case Part.Report:
                                if (!ProcessReport(ref data))
                                    goto END;
                                break;
                            case Part.End:
                                bulletinFinished = true;
                                goto END;
                        }
                    }

                    END:
                    return (data.Start, data.End, bulletinFinished);

                    void ProcessPartNone(ref ReadOnlySequence<byte> data)
                    {
                        marker = data.First.Span[0];
                        if (marker != StarMarker && marker != HashMarker)
                            throw GetInvalidFormatException(data.Start);

                        part = Part.FlagFieldSeparator;
                    }

                    bool ProcessFlagFieldSeparator(ref ReadOnlySequence<byte> data)
                    {
                        int length = marker == StarMarker ? 19 : Math.Max(18, blockLength);
                        if (data.Length < length)
                            return false;

                        Span<byte> span = stackalloc byte[length];
                        data.Slice(0, length).CopyTo(span);
                        if (marker == StarMarker)
                        {
                            ValidateMarkers(span, 0, StarMarkers, data);
                            totalLength = GetNumber(span.Slice(4, 10), data.GetPosition(4));
                            ValidateMarkers(span, 14, StarMarkers, data);
                            if (span[18] != (byte) '\n') throw GetInvalidFormatException(data.GetPosition(18));
                        }
                        else
                        {
                            ValidateMarkers(span, 0, HashMarkers, data);
                            blockLength = GetNumber(span.Slice(4, 3), data.Start);
                            if (blockLength > length)
                                return true; // We will allocate enough buffer on next loop.

                            bool isVariable = blockLength > 18;
                            totalLength = GetNumber(span.Slice(7, isVariable ? 11 : 6), data.GetPosition(7));
                            ValidateMarkers(span, blockLength - 5, HashMarkers, data);
                            if (span[blockLength - 1] != (byte) '\n')
                                throw GetInvalidFormatException(data.GetPosition(18));
                        }

                        data = data.Slice(length);
                        part = Part.BulletinHeading;
                        return true;

                        static void ValidateMarkers(in ReadOnlySpan<byte> span, int offset,
                            in ReadOnlyMemory<byte> pattern, in ReadOnlySequence<byte> data)
                        {
                            if (!span.Slice(offset, pattern.Length).SequenceEqual(pattern.Span))
                                throw GetInvalidFormatException(data.GetPosition(offset));
                        }
                    }

                    bool ProcessBulletinHeading(ref ReadOnlySequence<byte> data)
                    {
                        bulletinStart = data.Start;
                        var end = data.PositionOf((byte) '\r');
                        if (end == null)
                            return false;

                        var slice = data.Slice(data.Start, end.Value);
                        if (slice.IsSingleSegment)
                        {
                            BuildHeading(slice.First.Span, data);
                        }
                        else
                        {
                            Span<byte> span = stackalloc byte[(int) slice.Length];
                            slice.CopyTo(span);
                            BuildHeading(span, data);
                        }

                        data = data.Slice(end.Value);
                        part = HasSupplementaryIdentificationLine()
                            ? Part.SupplementaryIdentificationLine
                            : Part.Report;
                        return true;

                        void BuildHeading(in ReadOnlySpan<byte> span, in ReadOnlySequence<byte> data)
                        {
                            if (span.Length < 18)
                                throw GetInvalidFormatException(end.Value);

                            var type = WmoBulletinType.Normal;
                            bool multipart = false;
                            ushort index = 0;
                            if (span.Length >= 20)
                            {
                                if (span.Length < 22)
                                    throw GetInvalidFormatException(end.Value);

                                switch (span[19])
                                {
                                    case (byte) 'C':
                                        type = WmoBulletinType.Correction;
                                        index = span[21];
                                        break;
                                    case (byte) 'R':
                                        type = WmoBulletinType.Delayed;
                                        index = span[21];
                                        break;
                                    case (byte) 'A':
                                        type = WmoBulletinType.Amendment;
                                        index = span[21];
                                        break;
                                    case (byte) 'P':
                                        multipart = true;
                                        var key = span.Slice(0, 18).ToArray();
                                        if (builders.TryGetValue(key, out builder))
                                        {
                                            builder.Part = span[20] == (byte) 'Z'
                                                ? BulletinPart.Last
                                                : BulletinPart.Middle;
                                            if (builder.Part == BulletinPart.Last)
                                            {
                                                builders.Remove(key);
                                            }
                                        }
                                        else
                                        {
                                            builder = new BulletingBuilder
                                                {IsMultipart = true, Part = BulletinPart.First};
                                            builders.Add(key, builder);
                                        }

                                        index = (ushort) ((ushort) (span[20] << 8) | (ushort) span[21]);
                                        if (index < builder.Index)
                                            throw GetInvalidFormatException(data.GetPosition(20),
                                                "Invalid message part order.");
                                        break;
                                }
                            }

                            if (builder == null || (builder.IsMultipart && !multipart))
                            {
                                builder = new BulletingBuilder();
                            }

                            builder.Type = type;
                            builder.Index = index;

                            builder.T1 = span[0];
                            builder.T2 = span[1];
                            builder.A1 = span[2];
                            builder.A2 = span[3];
                            builder.ii = checked((byte) ((span[4] - '0') * 10 + (span[5] - '0')));

                            builder.Location = span.Slice(7, 4).ToArray();
                            int day = GetNumber(span.Slice(12, 2), data.GetPosition(12));
                            int hour = GetNumber(span.Slice(14, 2), data.GetPosition(14));
                            int minute = GetNumber(span.Slice(16, 2), data.GetPosition(16));
                            builder.Time = new DayHourMinute(day, hour, minute);
                        }

                        bool HasSupplementaryIdentificationLine()
                        {
                            if (hasSupplementaryIdentificationLine != null)
                                return hasSupplementaryIdentificationLine.Value;

                            // TODO: Determine whether the product has SupplementaryIdentificationLine
                            return true;
                        }
                    }

                    bool ProcessSupplementaryIdentificationLine(ref ReadOnlySequence<byte> data)
                    {
                        if (char.IsWhiteSpace((char) data.First.Span[0]))
                        {
                            data = data.Slice(1);
                            return true;
                        }

                        var end = data.PositionOf((byte) '\n');
                        if (end == null)
                            return false;

                        if (builder.Part == BulletinPart.First)
                        {
                            var slice = data.Slice(data.Start, end.Value);
                            if (slice.IsSingleSegment)
                            {
                                builder.SupplementaryIdentificationLine =
                                    GetSupplementaryIdentificationLine(slice.First.Span);
                            }
                            else
                            {
                                Span<byte> span = stackalloc byte[(int) slice.Length];
                                slice.CopyTo(span);
                                builder.SupplementaryIdentificationLine = GetSupplementaryIdentificationLine(span);
                            }
                        }

                        data = data.Slice(end.Value);
                        part = Part.Report;
                        return true;

                        string GetSupplementaryIdentificationLine(in ReadOnlySpan<byte> span)
                        {
                            int silEnd = span.LastIndexOf((byte) '\r');
                            return silEnd >= 0
                                ? Encoding.ASCII.GetString(span.Slice(0, silEnd - 1))
                                : Encoding.ASCII.GetString(span.Slice(0, span.Length - 1));
                        }
                    }

                    bool ProcessReport(ref ReadOnlySequence<byte> data)
                    {
                        if (char.IsWhiteSpace((char) data.First.Span[0]))
                        {
                            data = data.Slice(1);
                            return true;
                        }

                        if (data.First.Span[0] == (byte) '#')
                        {
                            part = Part.End;
                            return true;
                        }

                        var end = data.PositionOf((byte) '=');
                        if (end == null)
                            return false;

                        string report;
                        var slice = data.Slice(data.Start, end.Value);
                        if (slice.IsSingleSegment)
                        {
                            report = GetReport(slice.First.Span);
                        }
                        else
                        {
                            Span<byte> span = stackalloc byte[(int) slice.Length];
                            slice.CopyTo(span);
                            report = GetReport(span);
                        }

                        builder.TextReports.Add(report);
                        data = data.Slice(end.Value).Slice(1);
                        return true;

                        string GetReport(in ReadOnlySpan<byte> span)
                        {
                            return Encoding.ASCII.GetString(span.Slice(0, span.Length));
                        }
                    }

                    Exception GetInvalidFormatException(in SequencePosition pos, string msg = null)
                    {
                        return new InvalidOperationException("Invalid file format"); // TODO: Use custom exception
                    }

                    static int GetNumber(in ReadOnlySpan<byte> bytes, in SequencePosition pos)
                    {
                        int number = 0;
                        for (int i = 0; i < bytes.Length; i++)
                        {
                            int x = bytes[i] - (byte) '0';
                            if (x < 0 || x > 9)
                                throw GetInvalidFormatException(pos);

                            number = checked(number * 10 + x);
                        }

                        return number;
                    }
                }
            }
        }

        private class BulletingBuilder
        {
            public byte T1 { get; set; }
            public byte T2 { get; set; }
            public byte A1 { get; set; }
            public byte A2 { get; set; }
            public byte ii { get; set; }

            public byte[] Location { get; set; }

            public DayHourMinute Time { get; set; }

            public bool IsMultipart { get; set; }

            public BulletinPart Part { get; set; }

            public ushort Index { get; set; }

            public string SupplementaryIdentificationLine { get; set; }

            public List<string> TextReports { get; set; } = new List<string>();

            public MemoryStream BinaryReport { get; set; }

            public WmoBulletinType Type { get; set; }

            public WmoBulletin Build() => default;

            public void Reset()
            {
                T1 = 0;
                T2 = 0;
                A1 = 0;
                A2 = 0;
                ii = 0;
                Location = null;
                Time = default;
                IsMultipart = false;
                Part = BulletinPart.First;
                Index = 0;
                SupplementaryIdentificationLine = null;
                TextReports.Clear();
                BinaryReport?.SetLength(0);
                Type = default;
            }
        }

        private enum Part : byte
        {
            None,
            FlagFieldSeparator,
            BulletinHeading,
            SupplementaryIdentificationLine,
            Report,
            End
        }

        private enum BulletinPart : byte
        {
            First,
            Middle,
            Last
        }

        private class ByteArrayEqualityComparer : IEqualityComparer<byte[]>
        {
            public static readonly ByteArrayEqualityComparer Default = new ByteArrayEqualityComparer();

            static ByteArrayEqualityComparer() { }

            public bool Equals(byte[] x, byte[] y)
            {
                if (ReferenceEquals(x, null)) return ReferenceEquals(y, null);
                if (ReferenceEquals(x, y)) return true;
                return new Span<byte>(x).SequenceEqual(y);
            }

            public int GetHashCode(byte[] obj)
            {
                if (ReferenceEquals(obj, null))
                    return 0;

                var hashCode = new HashCode();
                foreach (var b in obj)
                {
                    hashCode.Add(b);
                }

                return hashCode.ToHashCode();
            }
        }
    }
}
