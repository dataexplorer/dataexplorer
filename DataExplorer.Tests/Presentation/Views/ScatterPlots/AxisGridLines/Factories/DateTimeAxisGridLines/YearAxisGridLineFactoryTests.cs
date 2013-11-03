using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Maps;
using DataExplorer.Domain.Maps.AxisMaps;
using DataExplorer.Presentation.Views.ScatterPlots.AxisGridLines.Factories.DateTimeAxisGridLines;
using NUnit.Framework;

namespace DataExplorer.Tests.Presentation.Views.ScatterPlots.AxisGridLines.Factories.DateTimeAxisGridLines
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
            var map = new DateTimeToAxisMap(DateTime.MinValue, DateTime.MaxValue, 0d, 1d);
            var results = _factory.Create(map, DateTime.MinValue, DateTime.MaxValue, 1000);
            Assert.That(results.Count(), Is.EqualTo(11));
            Assert.That(results.First().Position, Is.EqualTo(0d));
            Assert.That(results.Last().Position, Is.EqualTo(1d));
        }

        [Test]
        public void TestCreateShouldCreateCenturies()
        {
            AssertResults(100);
        }

        [Test]
        public void TestCreateShouldCreateDecades()
        {
            AssertResults(10);
        }

        [Test]
        public void TestCreateShouldCreateYears()
        {
           AssertResults(1);
        }

        private void AssertResults(int step)
        {
            var lower = new DateTime(2000, 1, 1);
            var upper = lower.AddYears(step * 10);
            var map = new DateTimeToAxisMap(lower, upper, 0d, 1d);
            var results = _factory.Create(map, lower, upper, step);
            Assert.That(results.Count(), Is.EqualTo(11));
            Assert.That(results.First().Position, Is.EqualTo(0d).Within(0.001));
            Assert.That(results.Last().Position, Is.EqualTo(1d).Within(0.001));
        }
    }
}
