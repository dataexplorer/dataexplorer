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
    public class DateTimeToLabelMapTests
    {
        private DateTimeToLabelMap _map;

        [SetUp]
        public void SetUp()
        {
            _map = new DateTimeToLabelMap();
        }

        [Test]
        public void TestMapWithNull()
        {
            var result = _map.Map(null);
            Assert.That(result, Is.EqualTo("Null"));
        }

        [Test]
        [TestCase("1/1/0001 00:00:00", "1/1/0001")]
        [TestCase("10/1/2500 06:15:15", "10/1/2500 6:15:15 AM")]
        [TestCase("7/2/5000 12:30:30", "7/2/5000 12:30:30 PM")]
        [TestCase("4/2/7500 18:45:45", "4/2/7500 6:45:45 PM")]
        [TestCase("12/31/9999 23:59:59", "12/31/9999 11:59:59 PM")]
        public void TestMapWithDateValues(string date, string expected)
        {
            var value = DateTime.Parse(date);
            var result = _map.Map(value);
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
