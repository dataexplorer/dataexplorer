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
    public class StringToAxisMapTests
    {
        [Test]
        [TestCase("Apple", 0d)]
        [TestCase("Elephant", 25d)]
        [TestCase("Monkey", 50d)]
        [TestCase("Tiger", 75d)]
        [TestCase("Zebra", 100d)]
        public void TestMapScenarios(string value, double expected)
        {
            var strings = new List<string> { "Apple", "Elephant", "Monkey", "Tiger", "Zebra" };
            var map = new StringToAxisMap(strings, 0, 100);
            var result = map.Map("Apple");
            Assert.That(result, Is.EqualTo(0));
        }
    }
}
