using System;
using System.Buffers;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using MeteoSharp.Bulletins;
using NUnit.Framework;

namespace MeteoSharp.Readers.Tests
{
    public class WmoBulletinReaderTests
    {
        [Test]
        public async Task SynopShort()
        {
            using var stream = OpenStream("synop.0001.data");

            var reader = new WmoBulletinReader();
            int count = 0;
            await foreach(var bulletin in reader.Read(stream))
            {
                bulletin.ProductType.Should().Be(WmoBulletinProductType.DecodableText);
                count += 1;
            }

            count.Should().Be(14);
        }

        [Test]
        public async Task SynopLong()
        {
            using var stream = OpenStream("synop.0113.data");

            var reader = new WmoBulletinReader();
            int count = 0;

            await foreach (var bulletin in reader.Read(stream))
            {
                bulletin.ProductType.Should().Be(WmoBulletinProductType.DecodableText);
                count += 1;
            }
            count.Should().Be(387);
        }

        [Test]
        public async Task RadarShort()
        {
            using var stream = OpenStream("radar.0000.data");

            var reader = new WmoBulletinReader();
            int count = 0;
            await foreach (var bulletin in reader.Read(stream))
            {
                bulletin.ProductType.Should().Be(WmoBulletinProductType.Binary);
                bulletin.BinaryReport.Length.Should().Be(21490);
                count += 1;
            }
            count.Should().Be(1);
        }

        [Test]
        public async Task RadarLong()
        {
            using var stream = OpenStream("radar.0002.data");

            var reader = new WmoBulletinReader();
            int count = 0;
            var actualLengths = new List<int>();
            await foreach (var bulletin in reader.Read(stream))
            {
                bulletin.ProductType.Should().Be(WmoBulletinProductType.Binary);
                actualLengths.Add(bulletin.BinaryReport.Length);
                count += 1;
            }
            count.Should().Be(6);

            int[] expectedLengths = { 17026, 21682, 7162, 7901, 104328, 44256 };
            actualLengths.Should().BeEquivalentTo(expectedLengths);
        }

        [Test]
        public async Task Sigmet()
        {
            using var stream = OpenStream("sigmet.0004.data");

            var reader = new WmoBulletinReader();
            int count = 0;
            await foreach (var bulletin in reader.Read(stream))
            {
                bulletin.ProductType.Should().Be(WmoBulletinProductType.PlainText);
                count += 1;
            }

            count.Should().Be(4);
        }

        [Test]
        public async Task TafXml()
        {
            using var stream = OpenStream("tafst.0020.data");

            var reader = new WmoBulletinReader(ResolveSuppId, xmlParsingBehavior: XmlParsingBehavior.ParseIgnoreErrors);
            int totalCount = 0;
            int parsedCount = 0;
            await foreach (var bulletin in reader.Read(stream))
            {
                bulletin.ProductType.Should().Be(WmoBulletinProductType.Xml);
                totalCount += 1;
                if (bulletin.XmlReport != null)
                {
                    parsedCount += 1;
                }
            }

            totalCount.Should().Be(176);
            parsedCount.Should().Be(172);

            string ResolveSuppId(ref ReadOnlySequence<byte> report, byte t1, byte t2)
            {
                var end = report.PositionOf((byte) '\n');
                if (end == null)
                    return null;

                var slice = report.Slice(0, end.Value);
                report = report.Slice(end.Value).Slice(1);

                if (slice.IsSingleSegment)
                {
                    return Encoding.ASCII.GetString(slice.First.Span).Trim();
                }

                Span<byte> span = stackalloc byte[(int)slice.Length];
                slice.CopyTo(span);
                return Encoding.ASCII.GetString(span).Trim();
            }
        }

        private Stream OpenStream(string name)
        {
            var assembly = Assembly.GetExecutingAssembly();
            return assembly.GetManifestResourceStream($"{GetType().Namespace}.Data.{name}");
        }
    }
}