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
    public class BooleanToLabelMapTests
    {
        private BooleanToLabelMap _map;

        [SetUp]
        public void SetUp()
        {
            _map = new BooleanToLabelMap();
        }

        [Test]
        [TestCase(null, "Null")]
        [TestCase(false, "False")]
        [TestCase(true, "True")]
        public void TestMapShouldReturnCorrectValues(bool? value, string expected)
        {
            var result = _map.Map(value);
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
