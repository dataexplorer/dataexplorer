using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Maps.AxisMaps;
using NUnit.Framework;

namespace DataExplorer.Tests.Domain.Maps.AxisMaps
{
    [TestFixture]
    public class IntegerToAxisMapTests
    {
        [Test]
        [TestCase(null, null)]
        [TestCase(-10, 0.00d)]
        [TestCase(-5, 0.25d)]
        [TestCase(0, 0.50d)]
        [TestCase(5, 0.75d)]
        [TestCase(10, 1.00d)]
        public void TestMapShouldReturnCorrectValues(int? value, double? expected)
        {
            var map = new IntegerToAxisMap(-10, 10, 0d, 1d);
            var result = map.Map(value);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void TestMapInverseWithLessThanMinValue()
        {
            var map = new IntegerToAxisMap(int.MinValue, int.MaxValue, 0d, 1d);
            var result = map.MapInverse(-0.1d);
            Assert.That(result, Is.EqualTo(int.MinValue));
        }

        [Test]
        public void TestMapInverseWithGreaterThanMaxValue()
        {
            var map = new IntegerToAxisMap(int.MinValue, int.MaxValue, 0d, 1d);
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
        public void TestMapInverseShouldReturnCorrectValues(double? value, int? expected)
        {
            var map = new IntegerToAxisMap(-10, 10, 0d, 1d);
            var result = map.MapInverse(value);
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
