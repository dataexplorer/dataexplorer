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
    public class IntegerToLabelMapTests
    {
        private IntegerToLabelMap _map;

        [SetUp]
        public void SetUp()
        {
            _map = new IntegerToLabelMap();
        }

        [Test]
        [TestCase(null, "Null")]
        [TestCase(-1000000, "-1.00E+006")]
        [TestCase(-100000, "-100000")]
        [TestCase(0, "0")]
        [TestCase(100000, "100000")]
        [TestCase(1000000, "1.00E+006")]
        public void TestMapShouldReturnCorrectValues(int? value, string expected)
        {
            var map = new IntegerToLabelMap();
            var result = map.Map(value);
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
