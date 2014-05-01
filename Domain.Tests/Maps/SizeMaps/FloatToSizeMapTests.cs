using DataExplorer.Domain.Layouts;
using DataExplorer.Domain.Maps.SizeMaps;
using NUnit.Framework;

namespace DataExplorer.Domain.Tests.Maps.SizeMaps
{
    [TestFixture]
    public class FloatToSizeMapTests
    {
        [Test]
        [TestCase(null, null)]
        [TestCase(-10d, 0.00d)]
        [TestCase(-5d, 0.25d)]
        [TestCase(0d, 0.50d)]
        [TestCase(5d, 0.75d)]
        [TestCase(10d, 1.00d)]
        public void TestMapShouldReturnAscendingValues(double? value, double? expected)
        {
            var map = new FloatToSizeMap(-10d, 10d, 0d, 1d, SortOrder.Ascending);
            var result = map.Map(value);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(null, null)]
        [TestCase(-10d, 1.00d)]
        [TestCase(-5d, 0.75d)]
        [TestCase(0d, 0.50d)]
        [TestCase(5d, 0.25d)]
        [TestCase(10d, 0.00d)]
        public void TestMapShouldReturnDescendingValues(double? value, double? expected)
        {
            var map = new FloatToSizeMap(-10d, 10d, 0d, 1d, SortOrder.Descending);
            var result = map.Map(value);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void TestMapInverseWithLessThanMinValue()
        {
            var map = new FloatToSizeMap(double.MinValue, double.MaxValue, 0d, 1d, SortOrder.Ascending);
            var result = map.MapInverse(-0.1d);
            Assert.That(result, Is.EqualTo(double.MinValue));
        }

        [Test]
        public void TestMapInverseWithGreaterThanMaxValue()
        {
            var map = new FloatToSizeMap(double.MinValue, double.MaxValue, 0d, 1d, SortOrder.Ascending);
            var result = map.MapInverse(1.1d);
            Assert.That(result, Is.EqualTo(double.MaxValue));
        }

        [Test]
        [TestCase(null, null)]
        [TestCase(0.00d, -10d)]
        [TestCase(0.25d, -5d)]
        [TestCase(0.50d, 0d)]
        [TestCase(0.75d, 5d)]
        [TestCase(1.00d, 10.0d)]
        public void TestMapInverseWithAscendingValues(double? value, double? expected)
        {
            var map = new FloatToSizeMap(-10d, 10d, 0d, 1d, SortOrder.Ascending);
            var result = map.MapInverse(value);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(null, null)]
        [TestCase(0.00d, 10d)]
        [TestCase(0.25d, 5d)]
        [TestCase(0.50d, 0d)]
        [TestCase(0.75d, -5d)]
        [TestCase(1.00d, -10.0d)]
        public void TestMapInverseWithDescendingValues(double? value, double? expected)
        {
            var map = new FloatToSizeMap(-10d, 10d, 0d, 1d, SortOrder.Descending);
            var result = map.MapInverse(value);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void TestMapInverseReturnsNullWhenResultIsNotANumber()
        {
            var map = new FloatToSizeMap(-10d, 10d, 0d, 0d, SortOrder.Ascending);
            var result = map.MapInverse(0d);
            Assert.That(result, Is.Null);
        }
    }
}
