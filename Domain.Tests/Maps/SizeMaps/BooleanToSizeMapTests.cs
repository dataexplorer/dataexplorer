using DataExplorer.Domain.Maps.SizeMaps;
using NUnit.Framework;

namespace DataExplorer.Domain.Tests.Maps.SizeMaps
{
    [TestFixture]
    public class BooleanToSizeMapTests
    {
        private BooleanToSizeMap _map;

        [SetUp]
        public void SetUp()
        {
            _map = new BooleanToSizeMap(0d, 1d);
        }

        [Test]
        [TestCase(null, null)]
        [TestCase(false, 0d)]
        [TestCase(true, 1d)]
        public void TestMapShouldReturnCorrectValues(bool? value, double? expected)
        {
            var result = _map.Map(value);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(null, null)]
        [TestCase(0d, false)]
        [TestCase(0.5d, true)]
        [TestCase(1d, true)]
        public void TestMapInverseShouldReturnCorrectValues(double? value, bool? expected)
        {
            var result = _map.MapInverse(value);
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
