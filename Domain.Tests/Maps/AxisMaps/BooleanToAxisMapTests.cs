using DataExplorer.Domain.Maps.AxisMaps;
using NUnit.Framework;

namespace DataExplorer.Domain.Tests.Maps.AxisMaps
{
    [TestFixture]
    public class BooleanToAxisMapTests
    {
        private BooleanToAxisMap _map;

        [SetUp]
        public void SetUp()
        {
            _map = new BooleanToAxisMap(0d, 1d);
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
