using System.Collections.Generic;
using DataExplorer.Domain.Maps.SizeMaps;
using NUnit.Framework;

namespace DataExplorer.Domain.Tests.Maps.SizeMaps
{
    [TestFixture]
    public class StringToSizeMapTests
    {
        [Test]
        [TestCase(null, null)]
        [TestCase("Apple", 0d)]
        [TestCase("Elephant", 0.25d)]
        [TestCase("Monkey", 0.50d)]
        [TestCase("Tiger", 0.75d)]
        [TestCase("Zebra", 1.00d)]
        public void TestMapShouldReturnCorrectValues(string value, double? expected)
        {
            var strings = new List<string> { "Apple", "Elephant", "Monkey", "Tiger", "Zebra" };
            var map = new StringToSizeMap(strings, 0d, 1d);
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
            var map = new StringToSizeMap(strings, 0d, 1d);
            var result = map.MapInverse(value);
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
