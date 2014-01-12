using System;
using System.Collections.Generic;
using System.Linq;
using DataExplorer.Domain.Maps.AxisMaps;
using DataExplorer.Domain.Views.ScatterPlots;
using DataExplorer.Presentation.Views.ScatterPlots.Grid.Factories.DateTimeGridLines;
using NUnit.Framework;

namespace DataExplorer.Tests.Presentation.Views.ScatterPlots.Grid.Factories.DateTimeGridLines
{
    [TestFixture]
    public class SecondAxisGridLineFactoryTests
    {
        private SecondAxisGridLineFactory _factory;

        [SetUp]
        public void SetUp()
        {
            _factory = new SecondAxisGridLineFactory();
        }

        [Test]
        public void TestCreateFourHoursShouldCreateCorrectValues()
        {
            var lower = new DateTime(2000, 1, 1);
            var upper = lower.AddSeconds(86400);
            var map = new DateTimeToAxisMap(lower, upper, 0d, 1d);
            var results = _factory.CreateFourHours(map, lower, upper).ToList();
            AssertResults(results, 7, 0d, "12:00:00 AM", 1d, "12:00:00 AM");
        }

        [Test]
        public void TestCreateHoursShouldCreateCorrectValues()
        {
            var lower = new DateTime(2000, 1, 1);
            var upper = lower.AddSeconds(14400);
            var map = new DateTimeToAxisMap(lower, upper, 0d, 1d);
            var results = _factory.CreateHours(map, lower, upper).ToList();
            AssertResults(results, 5, 0d, "12:00:00 AM", 1d, "4:00:00 AM");
        }

        [Test]
        public void TestCreateTenMinutesShouldCreateCorrectValues()
        {
            var lower = new DateTime(2000, 1, 1);
            var upper = lower.AddSeconds(3600);
            var map = new DateTimeToAxisMap(lower, upper, 0d, 1d);
            var results = _factory.CreateTenMinutes(map, lower, upper).ToList();
            AssertResults(results, 7, 0d, "12:00:00 AM", 1d, "1:00:00 AM");
        }

        [Test]
        public void TestCreateMinutesShouldCreateCorrectValues()
        {
            var lower = new DateTime(2000, 1, 1);
            var upper = lower.AddSeconds(600);
            var map = new DateTimeToAxisMap(lower, upper, 0d, 1d);
            var results = _factory.CreateMinutes(map, lower, upper).ToList();
            AssertResults(results, 11, 0d, "12:00:00 AM", 1d, "12:10:00 AM");
        }

        [Test]
        public void TestCreateTenSecondsShouldCreateCorrectValues()
        {
            var lower = new DateTime(2000, 1, 1);
            var upper = lower.AddSeconds(60);
            var map = new DateTimeToAxisMap(lower, upper, 0d, 1d);
            var results = _factory.CreateTenSeconds(map, lower, upper).ToList();
            AssertResults(results, 7, 0d, "12:00:00 AM", 1d, "12:01:00 AM");
        }

        [Test]
        public void TestCreateSecondsShouldCreateCorrectValues()
        {
            var lower = new DateTime(2000, 1, 1);
            var upper = lower.AddSeconds(10);
            var map = new DateTimeToAxisMap(lower, upper, 0d, 1d);
            var results = _factory.CreateSeconds(map, lower, upper).ToList();
            AssertResults(results, 11, 0d, "12:00:00 AM", 1d, "12:00:10 AM");
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
