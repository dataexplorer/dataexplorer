using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Maps.LabelMaps;
using NUnit.Framework;

namespace DataExplorer.Domain.Tests.Maps.LabelMaps
{
    [TestFixture]
    public class FloatToLabelMapTests
    {
        private FloatToLabelMap _map;

        [SetUp]
        public void SetUp()
        {
            _map = new FloatToLabelMap();
        }

        [Test]
        [TestCase(null, "Null")]
        [TestCase(-1000000d, "-1.00E+006")]
        [TestCase(-100000d, "-100,000.00")]
        [TestCase(-0.01d, "-0.01")]
        [TestCase(-0.001d, "-1.00E-003")]
        [TestCase(0d, "0.00")]
        [TestCase(0.001d, "1.00E-003")]
        [TestCase(0.01d, "0.01")]
        [TestCase(100000d, "100,000.00")]
        [TestCase(1000000d, "1.00E+006")]
        public void TestMapShouldReturnCorrectValues(double? value, string expected)
        {
            var result = _map.Map(value);
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
