using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using NUnit.Framework;

namespace MeteoSharp.Readers.Tests
{
    public class WmoBulletinReaderTests
    {
        [Test]
        public async Task Synop()
        {
            using var stream = OpenStream("synop.0001.txt");

            var reader = new WmoBulletinReader();
            int count = 0;
            await foreach(var bulletin in reader.Read(stream))
            {
                count += 1;
            }
            Assert.That(count, Is.GreaterThan(1));
        }

        private Stream OpenStream(string name)
        {
            var assembly = Assembly.GetExecutingAssembly();
            return assembly.GetManifestResourceStream($"{GetType().Namespace}.Data.{name}");
        }
    }
}