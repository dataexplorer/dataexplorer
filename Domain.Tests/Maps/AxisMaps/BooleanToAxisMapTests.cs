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
        [TestCase(null, null)]
        [TestCase(false, 0d)]
        [TestCase(true, 1d)]
        public void TestMapShouldReturnCorrectValues(bool? value, double? expected)
        {
            var map = new BooleanToAxisMap(0d, 1d);
            var result = map.Map(value);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(null, null)]
        [TestCase(0d, false)]
        [TestCase(0.5d, true)]
        [TestCase(1d, true)]
        public void TestMapInverseShouldReturnCorrectValues(double? value, bool? expected)
        {
            var map = new BooleanToAxisMap(0d, 1d);
            var result = map.MapInverse(value);
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
