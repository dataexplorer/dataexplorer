using System;
using System.Linq;
using DataExplorer.Application.Views.ScatterPlots.Axes.Factories.DateTimeGridLines;
using DataExplorer.Domain.Layouts;
using DataExplorer.Domain.Maps.AxisMaps;
using NUnit.Framework;

namespace DataExplorer.Application.Tests.Views.ScatterPlots.Axes.Factories.DateTimeGridLines
{
    [TestFixture]
    public class YearAxisGridLineFactoryTests
    {
        private YearAxisGridLineFactory _factory;
        
        [SetUp]
        public void SetUp()
        {
            _factory = new YearAxisGridLineFactory();
        }

        [Test]
        public void TestCreateShouldCreateMillenia()
        {
            var map = new DateTimeToAxisMap(DateTime.MinValue, DateTime.MaxValue, 0d, 1d, SortOrder.Ascending);
            var results = _factory.Create(map, DateTime.MinValue, DateTime.MaxValue, 1000);
            Assert.That(results.Count(), Is.EqualTo(11));
            Assert.That(results.First().LabelName, Is.EqualTo("0001"));
            Assert.That(results.First().Position, Is.EqualTo(0d));
            Assert.That(results.Last().LabelName, Is.EqualTo("9999"));
            Assert.That(results.Last().Position, Is.EqualTo(1d));
        }

        [Test]
        public void TestCreateShouldCreateCenturies()
        {
            AssertResults(100, "2000", "3000");
        }

        [Test]
        public void TestCreateShouldCreateDecades()
        {
            AssertResults(10, "2000", "2100");
        }

        [Test]
        public void TestCreateShouldCreateYears()
        {
           AssertResults(1, "2000", "2010");
        }

        private void AssertResults(int step, string startLabel, string endLabel)
        {
            var lower = new DateTime(2000, 1, 1);
            var upper = lower.AddYears(step * 10);
            var map = new DateTimeToAxisMap(lower, upper, 0d, 1d, SortOrder.Ascending);
            var results = _factory.Create(map, lower, upper, step);
            Assert.That(results.Count(), Is.EqualTo(11));
            Assert.That(results.First().Position, Is.EqualTo(0d).Within(0.001));
            Assert.That(results.First().LabelName, Is.EqualTo(startLabel));
            Assert.That(results.Last().Position, Is.EqualTo(1d).Within(0.001));
            Assert.That(results.Last().LabelName, Is.EqualTo(endLabel));
        }
    }
}
