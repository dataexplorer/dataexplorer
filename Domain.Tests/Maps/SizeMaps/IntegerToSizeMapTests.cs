using DataExplorer.Domain.Layouts;
using DataExplorer.Domain.Maps.SizeMaps;
using NUnit.Framework;

namespace DataExplorer.Domain.Tests.Maps.SizeMaps
{
    [TestFixture]
    public class IntegerToSizeMapTests
    {
        [Test]
        [TestCase(null, null)]
        [TestCase(-10, 0.00d)]
        [TestCase(-5, 0.25d)]
        [TestCase(0, 0.50d)]
        [TestCase(5, 0.75d)]
        [TestCase(10, 1.00d)]
        public void TestMapShouldReturnAscendingValues(int? value, double? expected)
        {
            var map = new IntegerToSizeMap(-10, 10, 0d, 1d, SortOrder.Ascending);
            var result = map.Map(value);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(null, null)]
        [TestCase(-10, 1.00d)]
        [TestCase(-5, 0.75d)]
        [TestCase(0, 0.50d)]
        [TestCase(5, 0.25d)]
        [TestCase(10, 0.00d)]
        public void TestMapShouldReturnDescendingValues(int? value, double? expected)
        {
            var map = new IntegerToSizeMap(-10, 10, 0d, 1d, SortOrder.Descending);
            var result = map.Map(value);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void TestMapInverseWithLessThanMinValue()
        {
            var map = new IntegerToSizeMap(int.MinValue, int.MaxValue, 0d, 1d, SortOrder.Ascending);
            var result = map.MapInverse(-0.1d);
            Assert.That(result, Is.EqualTo(int.MinValue));
        }

        [Test]
        public void TestMapInverseWithGreaterThanMaxValue()
        {
            var map = new IntegerToSizeMap(int.MinValue, int.MaxValue, 0d, 1d, SortOrder.Ascending);
            var result = map.MapInverse(1.1d);
            Assert.That(result, Is.EqualTo(int.MaxValue));
        }

        [Test]
        [TestCase(null, null)]
        [TestCase(0.00d, -10)]
        [TestCase(0.25d, -5)]
        [TestCase(0.50d, 0)]
        [TestCase(0.75d, 5)]
        [TestCase(1.00d, 10)]
        public void TestMapInverseShouldReturnAscendingValues(double? value, int? expected)
        {
            var map = new IntegerToSizeMap(-10, 10, 0d, 1d, SortOrder.Ascending);
            var result = map.MapInverse(value);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(null, null)]
        [TestCase(0.00d, 10)]
        [TestCase(0.25d, 5)]
        [TestCase(0.50d, 0)]
        [TestCase(0.75d, -5)]
        [TestCase(1.00d, -10)]
        public void TestMapInverseShouldReturnDescendingValues(double? value, int? expected)
        {
            var map = new IntegerToSizeMap(-10, 10, 0d, 1d, SortOrder.Descending);
            var result = map.MapInverse(value);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void TestMapInverseReturnsNullWhenResultIsNotANumber()
        {
            var map = new IntegerToSizeMap(-10, 10, 0d, 0d, SortOrder.Ascending);
            var result = map.MapInverse(0d);
            Assert.That(result, Is.Null);
        }
    }
}
