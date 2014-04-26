using System;
using System.Collections.Generic;
using System.Linq;
using DataExplorer.Application.Views.ScatterPlots.Axes.Factories.DateTimeGridLines;
using DataExplorer.Domain.Maps.AxisMaps;
using DataExplorer.Domain.Views.ScatterPlots;
using NUnit.Framework;

namespace DataExplorer.Application.Tests.Views.ScatterPlots.Axes.Factories.DateTimeGridLines
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
            var map = new DateTimeToAxisMap(lower, upper, 0d, 1d, false);
            var results = _factory.CreateQuarters(map, lower, upper).ToList();
            AssertResults(results, 5, 0d, "1/1/2000", 1d, "1/1/2001");
        }

        [Test]
        public void TestCreateShouldCreateMonths()
        {
            var lower = new DateTime(2000, 1, 1);
            var upper = lower.AddDays(90);
            var map = new DateTimeToAxisMap(lower, upper, 0d, 1d, false);
            var results = _factory.CreateMonths(map, lower, upper).ToList();
            AssertResults(results, 4, 0d, "1/1/2000", 1d, "4/1/2000");
        }

        [Test]
        public void TestCreateShouldCreateWeeks()
        {
            var lower = new DateTime(2000, 1, 1);
            var upper = lower.AddDays(30);
            var map = new DateTimeToAxisMap(lower, upper, 0d, 1d, false);
            var results = _factory.CreateWeeks(map, lower, upper).ToList();
            AssertResults(results, 7, -0.16d, "12/27/1999", 1.23d, "2/7/2000");
        }

        [Test]
        public void TestCreateShouldCreateDays()
        {
            var lower = new DateTime(2000, 1, 1);
            var upper = lower.AddDays(7);
            var map = new DateTimeToAxisMap(lower, upper, 0d, 1d, false);
            var results = _factory.CreateDays(map, lower, upper).ToList();
            AssertResults(results, 8, 0d, "1/1/2000", 1d, "1/8/2000");
        }

        private void AssertResults(List<AxisGridLine> results, int count, double firstPosition, string firstLabel, double lastPosition, string lastLabel)
        {
            Assert.That(results.Count(), Is.EqualTo(count));
            Assert.That(results.First().Position, Is.EqualTo(firstPosition).Within(0.1));
            Assert.That(results.First().LabelName, Is.EqualTo(firstLabel));
            Assert.That(results.Last().Position, Is.EqualTo(lastPosition).Within(0.1));
            Assert.That(results.Last().LabelName, Is.EqualTo(lastLabel));
        }
    }
}
