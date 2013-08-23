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
        [TestCase(0, 0d)]
        [TestCase(2, 20d)]
        [TestCase(5, 50d)]
        [TestCase(7, 70d)]
        [TestCase(10, 100d)]
        public void TestPositiveSourceAndPositiveTargetMapScenarios(int value, double expected)
        {
            var map = new IntegerToAxisMap(0, 10, 0d, 100d);
            var result = map.Map(value);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(-10, 0d)]
        [TestCase(-7, 30d)]
        [TestCase(-5, 50d)]
        [TestCase(-2, 80d)]
        [TestCase(0, 100d)]
        public void TestNegativeSourceAndPositiveTargetMapScenarios(int value, double expected)
        {
            var map = new IntegerToAxisMap(-10, 0, 0d, 100d);
            var result = map.Map(value);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(0, -100d)]
        [TestCase(2, -80d)]
        [TestCase(5, -50d)]
        [TestCase(7, -30d)]
        [TestCase(10, 0d)]
        public void TestPositiveSourceAndNegativeTargetMapScenarios(int value, double expected)
        {
            var map = new IntegerToAxisMap(0, 10, -100d, 0d);
            var result = map.Map(value);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(-10, -100d)]
        [TestCase(-7, -70d)]
        [TestCase(-5, -50d)]
        [TestCase(-2, -20d)]
        [TestCase(0, 0d)]
        public void TestNegativeSourceAndNegativeTargetMapScenarios(int value, double expected)
        {
            var map = new IntegerToAxisMap(-10, 0, -100d, 0d);
            var result = map.Map(value);
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
