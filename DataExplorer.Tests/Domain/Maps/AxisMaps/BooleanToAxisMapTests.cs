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
    public class BooleanToAxisMapTests
    {
        [Test]
        [TestCase(false, 0d)]
        [TestCase(true, 10d)]
        public void TestPositiveMapScenarios(bool value, double expected)
        {
            var map = new BooleanToAxisMap(0d, 10d);
            var result = map.Map(value);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(false, -10d)]
        [TestCase(true, 0d)]
        public void TestNegativeMapScenarios(bool value, double expected)
        {
            var map = new BooleanToAxisMap(-10d, 0d);
            var result = map.Map(value);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(false, -10d)]
        [TestCase(true, 10d)]
        public void TestPositiveAndNegativeMapScenarios(bool value, double expected)
        {
            var map = new BooleanToAxisMap(-10d, 10d);
            var result = map.Map(value);
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
