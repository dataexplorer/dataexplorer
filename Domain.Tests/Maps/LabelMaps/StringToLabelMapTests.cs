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
    public class StringToLabelMapTests
    {
        private StringToLabelMap _map;

        [SetUp]
        public void SetUp()
        {
            _map = new StringToLabelMap();
        }

        [Test]
        [TestCase(null, "[Null]")]
        [TestCase("", "[Empty]")]
        [TestCase("Test", "Test")]
        public void TestMapShouldReturnCorrectValues(string value, string expected)
        {
            var result = _map.Map(value);
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
