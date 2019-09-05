using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using NUnit.Framework;

namespace MeteoSharp.Readers.Tests
{
    public class WmoBulletinReaderTests
    {
        [Test]
        public async Task SynopShort()
        {
            await using var stream = OpenStream("synop.0001.data");

            var reader = new WmoBulletinReader();
            int count = 0;
            await foreach(var bulletin in reader.Read(stream))
            {
                count += 1;
            }
            Assert.That(count, Is.EqualTo(14));
        }

        [Test]
        public async Task SynopLong()
        {
            await using var stream = OpenStream("synop.0113.data");

            var reader = new WmoBulletinReader();
            int count = 0;

            await foreach (var bulletin in reader.Read(stream))
            {
                count += 1;
            }
            Assert.That(count, Is.EqualTo(387));
        }

        private Stream OpenStream(string name)
        {
            var assembly = Assembly.GetExecutingAssembly();
            return assembly.GetManifestResourceStream($"{GetType().Namespace}.Data.{name}");
        }
    }
}