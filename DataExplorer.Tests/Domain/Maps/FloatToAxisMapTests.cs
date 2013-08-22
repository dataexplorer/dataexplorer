using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Maps;
using NUnit.Framework;

namespace DataExplorer.Tests.Domain.Maps
{
    [TestFixture]
    public class FloatToAxisMapTests
    {
        [Test]
        [TestCase(0d, 0d)]
        [TestCase(2.5d, 25d)]
        [TestCase(5.0d, 50d)]
        [TestCase(7.5d, 75d)]
        [TestCase(10d, 100d)]
        public void TestPositiveMapScenarios(double value, double expected)
        {
            var map = new FloatToAxisMap(0d, 10d, 0d, 100d);
            var result = map.Map(value);
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
