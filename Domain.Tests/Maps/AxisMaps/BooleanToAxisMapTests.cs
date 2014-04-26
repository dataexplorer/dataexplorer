using DataExplorer.Domain.Maps.AxisMaps;
using NUnit.Framework;

namespace DataExplorer.Domain.Tests.Maps.AxisMaps
{
    [TestFixture]
    public class BooleanToAxisMapTests
    {
        [Test]
        [TestCase(null, false, null)]
        [TestCase(false, false, 0d)]
        [TestCase(true, false, 1d)]
        [TestCase(false, true, 1d)]
        [TestCase(true, true, 0d)]
        public void TestMapShouldReturnCorrectValues(bool? value, bool isReverse, double? expected)
        {
            var map = new BooleanToAxisMap(0d, 1d, isReverse);
            var result = map.Map(value);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(null, false, null)]
        [TestCase(0d, false, false)]
        [TestCase(0.5d, false, true)]
        [TestCase(1d, false, true)]
        [TestCase(0d, true, true)]
        [TestCase(0.5d, true, true)]
        [TestCase(1d, true, false)]
        public void TestMapInverseShouldReturnCorrectValues(double? value, bool isReverse, bool? expected)
        {
            var map = new BooleanToAxisMap(0d, 1d, isReverse);
            var result = map.MapInverse(value);
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
