using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Maps.AxisMaps;
using DataExplorer.Presentation.Views.ScatterPlots.AxisGridLines.Factories.DateTimeAxisGridLines;
using NUnit.Framework;

namespace DataExplorer.Tests.Presentation.Views.ScatterPlots.AxisGridLines.Factories.DateTimeAxisGridLines
{
    [TestFixture]
    public class DayAxisGridLineFactoryTests
    {
        private DayAxisGridLineFactory _factory;

        [SetUp]
        public void SetUp()
        {
            _factory = new DayAxisGridLineFactory();
        }

        [Test]
        public void TestCreateShouldCreateQuarterYears()
        {
            var lower = new DateTime(2000, 1, 1);
            var upper = lower.AddDays(365);
            var map = new DateTimeToAxisMap(lower, upper, 0d, 1d);
            var results = _factory.CreateQuarters(map, lower, upper);
            Assert.That(results.Count(), Is.EqualTo(4));
            Assert.That(results.First().Position, Is.EqualTo(0d).Within(0.1));
            Assert.That(results.Last().Position, Is.EqualTo(0.75d).Within(0.1));
        }

        [Test]
        [TestCase(90, 30, 4, 0d, 1d)]
        public void TestCreateShouldCreateMonths(int width, int step, int count, double low, double high)
        {
            var lower = new DateTime(2000, 1, 1);
            var upper = lower.AddDays(width);
            var map = new DateTimeToAxisMap(lower, upper, 0d, 1d);
            var results = _factory.CreateMonths(map, lower, upper);
            Assert.That(results.Count(), Is.EqualTo(count));
            Assert.That(results.First().Position, Is.EqualTo(low).Within(0.1));
            Assert.That(results.Last().Position, Is.EqualTo(high).Within(0.1));
        }

        [Test]
        [TestCase(30, 7, 7, -0.16d, 1.23d)]
        public void TestCreateShouldCreateWeeks(int width, int step, int count, double low, double high)
        {
            var lower = new DateTime(2000, 1, 1);
            var upper = lower.AddDays(width);
            var map = new DateTimeToAxisMap(lower, upper, 0d, 1d);
            var results = _factory.CreateWeeks(map, lower, upper);
            Assert.That(results.Count(), Is.EqualTo(count));
            Assert.That(results.First().Position, Is.EqualTo(low).Within(0.1));
            Assert.That(results.Last().Position, Is.EqualTo(high).Within(0.1));
        }

        [Test]
        [TestCase(7, 1, 8, 0d, 1d)]
        public void TestCreateShouldCreateDays(int width, int step, int count, double low, double high)
        {
            var lower = new DateTime(2000, 1, 1);
            var upper = lower.AddDays(width);
            var map = new DateTimeToAxisMap(lower, upper, 0d, 1d);
            var results = _factory.CreateDays(map, lower, upper);
            Assert.That(results.Count(), Is.EqualTo(count));
            Assert.That(results.First().Position, Is.EqualTo(low).Within(0.1));
            Assert.That(results.Last().Position, Is.EqualTo(high).Within(0.1));
        }
    }
}
