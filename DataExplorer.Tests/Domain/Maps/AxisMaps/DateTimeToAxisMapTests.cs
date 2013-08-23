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
    public class DateTimeToAxisMapTests
    {
        [Test]
        [TestCase("1/1/0001", 0d)]
        [TestCase("10/1/2500", 25d)]
        [TestCase("7/2/5000", 50d)]
        [TestCase("4/2/7500", 75d)]
        [TestCase("12/31/9999", 100d)]
        public void TestDateMapScenarios(string date, double expected)
        {
            var map = new DateTimeToAxisMap(DateTime.MinValue, DateTime.MaxValue, 0d, 100d);
            var value = DateTime.Parse(date);
            var result = map.Map(value);
            Assert.That(result, Is.EqualTo(expected).Within(0.0001));
        }

        [Test]
        [TestCase("1/1/0001 00:00:00", 0d)]
        [TestCase("1/1/0001 06:00:00", 25d)]
        [TestCase("1/1/0001 12:00:00", 50d)]
        [TestCase("1/1/0001 18:00:00", 75d)]
        [TestCase("1/2/0001 00:00:00", 100d)]
        public void TestTimeMapScenarios(string time, double expected)
        {
            var min = DateTime.Parse("1/1/0001 00:00:00");
            var max = DateTime.Parse("1/2/0001 00:00:00");
            var map = new DateTimeToAxisMap(min, max, 0d, 100d);
            var value = DateTime.Parse(time);
            var result = map.Map(value);
            Assert.That(result, Is.EqualTo(expected).Within(0.0001));
        }

        [Test]
        [TestCase("1/1/0001 00:00:00.000", 0d)]
        [TestCase("1/1/0001 00:00:00.250", 25d)]
        [TestCase("1/1/0001 00:00:00.500", 50d)]
        [TestCase("1/1/0001 00:00:00.750", 75d)]
        [TestCase("1/1/0001 00:00:01.000", 100d)]
        public void TestMillisecondsMapScenarios(string time, double expected)
        {
            var min = DateTime.Parse("1/1/0001 00:00:00.000");
            var max = DateTime.Parse("1/1/0001 00:00:01.000");
            var map = new DateTimeToAxisMap(min, max, 0d, 100d);
            var value = DateTime.Parse(time);
            var result = map.Map(value);
            Assert.That(result, Is.EqualTo(expected).Within(0.0001));
        }

        [Test]
        public void TestTimeMapScenarios()
        {
            var mid = (DateTime.MinValue.Ticks + DateTime.MaxValue.Ticks) / 4;
            var midDateTime = new DateTime(mid * 3);
        }
    }
}
