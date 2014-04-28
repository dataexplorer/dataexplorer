using DataExplorer.Domain.Layouts;
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
            _map = new BooleanToSizeMap(0d, 1d, SortOrder.Ascending);
        }

        [Test]
        [TestCase(null, null)]
        [TestCase(false, 0d)]
        [TestCase(true, 1d)]
        public void TestMapShouldReturnAscendingValues(bool? value, double? expected)
        {
            var result = _map.Map(value);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(null, null)]
        [TestCase(false, 1d)]
        [TestCase(true, 0d)]
        public void TestMapShouldReturnDescendingValues(bool? value, double? expected)
        {
            _map = new BooleanToSizeMap(0d, 1d, SortOrder.Descending);
            var result = _map.Map(value);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(null, null)]
        [TestCase(0d, false)]
        [TestCase(0.5d, true)]
        [TestCase(1d, true)]
        public void TestMapInverseShouldReturnAscendingValues(double? value, bool? expected)
        {
            var result = _map.MapInverse(value);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(null, null)]
        [TestCase(0d, true)]
        [TestCase(0.5d, true)]
        [TestCase(1d, false)]
        public void TestMapInverseShouldReturnDescendingValues(double? value, bool? expected)
        {
            _map = new BooleanToSizeMap(0d, 1d, SortOrder.Descending);
            var result = _map.MapInverse(value);
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
