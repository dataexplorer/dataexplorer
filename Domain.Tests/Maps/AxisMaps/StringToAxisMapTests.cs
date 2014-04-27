using System.Collections.Generic;
using DataExplorer.Domain.Layouts;
using DataExplorer.Domain.Maps.AxisMaps;
using NUnit.Framework;

namespace DataExplorer.Domain.Tests.Maps.AxisMaps
{
    [TestFixture]
    public class StringToAxisMapTests
    {
        [Test]
        [TestCase(null, null)]
        [TestCase("Apple", 0.00d)]
        [TestCase("Elephant", 0.25d)]
        [TestCase("Monkey", 0.50d)]
        [TestCase("Tiger", 0.75d)]
        [TestCase("Zebra", 1.00d)]
        public void TestMapShouldReturnCorrectValues(string value, double? expected)
        {
            var strings = new List<string> { "Apple", "Elephant", "Monkey", "Tiger", "Zebra" };
            var map = new StringToAxisMap(strings, 0d, 1d, SortOrder.Ascending);
            var result = map.Map(value);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(null, null)]
        [TestCase("Apple", 1.00d)]
        [TestCase("Elephant", 0.75d)]
        [TestCase("Monkey", 0.50d)]
        [TestCase("Tiger", 0.25d)]
        [TestCase("Zebra", 0.00d)]
        public void TestMapShouldReturnDescendingValues(string value, double? expected)
        {
            var strings = new List<string> { "Apple", "Elephant", "Monkey", "Tiger", "Zebra" };
            var map = new StringToAxisMap(strings, 0d, 1d, SortOrder.Descending);
            var result = map.Map(value);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(null, null)]
        [TestCase(-0.1d, "Apple")]
        [TestCase(0d, "Apple")]
        [TestCase(0.25d, "Elephant")]
        [TestCase(0.50d, "Monkey")]
        [TestCase(0.75d, "Tiger")]
        [TestCase(1.00d, "Zebra")]
        [TestCase(1.1d, "Zebra")]
        public void TestMapInverseShouldReturnCorrectValues(double? value, string expected)
        {
            var strings = new List<string> { "Apple", "Elephant", "Monkey", "Tiger", "Zebra" };
            var map = new StringToAxisMap(strings, 0d, 1d, SortOrder.Ascending);
            var result = map.MapInverse(value);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(null, null)]
        [TestCase(-0.1d, "Zebra")]
        [TestCase(0d, "Zebra")]
        [TestCase(0.25d, "Tiger")]
        [TestCase(0.50d, "Monkey")]
        [TestCase(0.75d, "Elephant")]
        [TestCase(1.00d, "Apple")]
        [TestCase(1.1d, "Apple")]
        public void TestMapInverseShouldReturnDescendingValues(double? value, string expected)
        {
            var strings = new List<string> { "Apple", "Elephant", "Monkey", "Tiger", "Zebra" };
            var map = new StringToAxisMap(strings, 0d, 1d, SortOrder.Descending);
            var result = map.MapInverse(value);
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
