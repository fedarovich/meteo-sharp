using System;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using MeteoSharp.Time;

namespace MeteoSharp.Bulletins
{
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    [SuppressMessage("ReSharper", "ConvertToAutoProperty")]
    public readonly struct WmoBulletin
    {
        private readonly byte _t1;
        private readonly byte _t2;
        private readonly byte _a1;
        private readonly byte _a2;
        private readonly byte _ii;
        private readonly byte _reserved;
        private readonly WmoBulletinType _type;
        private readonly byte _bbbIndex;
        private readonly uint _cccc;
        private readonly DayHourMinute _time;
        private readonly object _report;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public WmoBulletin(
            byte t1, 
            byte t2, 
            byte a1, 
            byte a2, 
            byte ii, 
            WmoBulletinType type, 
            byte bbbIndex, 
            uint cccc, 
            DayHourMinute time, 
            IEnumerable<string> reports) : this(t1, t2, a1, a2, ii, type, bbbIndex, cccc, time, reports.ToList())
        {
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public WmoBulletin(
            byte t1,
            byte t2,
            byte a1,
            byte a2,
            byte ii,
            WmoBulletinType type,
            byte bbbIndex,
            uint cccc,
            DayHourMinute time,
            IEnumerable<byte> binaryReport) : this(t1, t2, a1, a2, ii, type, bbbIndex, cccc, time, binaryReport.ToArray())
        {
        }

        internal WmoBulletin(
            byte t1,
            byte t2,
            byte a1,
            byte a2,
            byte ii,
            WmoBulletinType type,
            byte bbbIndex,
            uint cccc,
            DayHourMinute time,
            List<string> reports
            ) : this()
        {
            _t1 = t1;
            _t2 = t2;
            _a1 = a1;
            _a2 = a2;
            _ii = ii;
            _type = type;
            _bbbIndex = bbbIndex;
            _cccc = cccc;
            _time = time;
            _report = reports.ToArray();
        }

        internal WmoBulletin(
            byte t1,
            byte t2,
            byte a1,
            byte a2,
            byte ii,
            WmoBulletinType type,
            byte bbbIndex,
            uint cccc,
            DayHourMinute time,
            byte[] binaryReport) : this()
        {
            _t1 = t1;
            _t2 = t2;
            _a1 = a1;
            _a2 = a2;
            _ii = ii;
            _type = type;
            _bbbIndex = bbbIndex;
            _cccc = cccc;
            _time = time;
            _report = binaryReport.ToArray();
        }

        public char T1 => (char)_t1;
        public char T2 => (char)_t2;
        public char A1 => (char)_a1;
        public char A2 => (char)_a2;
        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public byte ii => _ii;
        
        public WmoBulletinType Type => _type;
        public byte Index => _bbbIndex;
        public char IndexChar => (char)('A' + _bbbIndex);
        public bool IsLost => _bbbIndex == ('Y' - 'A');
        public bool IsCompiled => _bbbIndex == ('Z' - 'A');

        public unsafe string Location
        {
            get
            {
                Span<byte> cccc = stackalloc byte[4];
                BinaryPrimitives.WriteUInt32LittleEndian(cccc, _cccc);
                fixed (void* p = cccc)
                {
                    return Encoding.ASCII.GetString((byte*) p, 4);
                }
            }
        }

        public DayHourMinute Time => _time;

        public IReadOnlyList<string> TextReports => _report as IReadOnlyList<string>;

        public ReadOnlyMemory<byte> BinaryReport => new ReadOnlyMemory<byte>(_report as byte[]);
    }
}
