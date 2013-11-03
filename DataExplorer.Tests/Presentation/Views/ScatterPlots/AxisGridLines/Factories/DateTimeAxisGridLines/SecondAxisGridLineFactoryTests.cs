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
            var width = 86400;
            var lower = new DateTime(2000, 1, 1);
            var upper = lower.AddSeconds(width);
            var map = new DateTimeToAxisMap(lower, upper, 0d, 1d);
            var results = _factory.CreateFourHours(map, lower, upper);
            Assert.That(results.Count(), Is.EqualTo(7));
            Assert.That(results.First().Position, Is.EqualTo(0d).Within(0.001d));
            Assert.That(results.Last().Position, Is.EqualTo(1d).Within(0.001d));
        }

        [Test]
        public void TestCreateHoursShouldCreateCorrectValues()
        {
            var width = 14400;
            var lower = new DateTime(2000, 1, 1);
            var upper = lower.AddSeconds(width);
            var map = new DateTimeToAxisMap(lower, upper, 0d, 1d);
            var results = _factory.CreateHours(map, lower, upper);
            Assert.That(results.Count(), Is.EqualTo(5));
            Assert.That(results.First().Position, Is.EqualTo(0d).Within(0.001d));
            Assert.That(results.Last().Position, Is.EqualTo(1d).Within(0.001d));
        }

        [Test]
        public void TestCreateTenMinutesShouldCreateCorrectValues()
        {
            var width = 3600;
            var lower = new DateTime(2000, 1, 1);
            var upper = lower.AddSeconds(width);
            var map = new DateTimeToAxisMap(lower, upper, 0d, 1d);
            var results = _factory.CreateTenMinutes(map, lower, upper);
            Assert.That(results.Count(), Is.EqualTo(7));
            Assert.That(results.First().Position, Is.EqualTo(0d).Within(0.001d));
            Assert.That(results.Last().Position, Is.EqualTo(1d).Within(0.001d));
        }

        [Test]
        public void TestCreateMinutesShouldCreateCorrectValues()
        {
            var width = 600;
            var lower = new DateTime(2000, 1, 1);
            var upper = lower.AddSeconds(width);
            var map = new DateTimeToAxisMap(lower, upper, 0d, 1d);
            var results = _factory.CreateMinutes(map, lower, upper);
            Assert.That(results.Count(), Is.EqualTo(11));
            Assert.That(results.First().Position, Is.EqualTo(0d).Within(0.001d));
            Assert.That(results.Last().Position, Is.EqualTo(1d).Within(0.001d));
        }

        [Test]
        public void TestCreateTenSecondsShouldCreateCorrectValues()
        {
            var width = 60;
            var lower = new DateTime(2000, 1, 1);
            var upper = lower.AddSeconds(width);
            var map = new DateTimeToAxisMap(lower, upper, 0d, 1d);
            var results = _factory.CreateTenSeconds(map, lower, upper);
            Assert.That(results.Count(), Is.EqualTo(7));
            Assert.That(results.First().Position, Is.EqualTo(0d).Within(0.001d));
            Assert.That(results.Last().Position, Is.EqualTo(1d).Within(0.001d));
        }

        [Test]
        public void TestCreateSecondsShouldCreateCorrectValues()
        {
            var width = 10;
            var lower = new DateTime(2000, 1, 1);
            var upper = lower.AddSeconds(width);
            var map = new DateTimeToAxisMap(lower, upper, 0d, 1d);
            var results = _factory.CreateSeconds(map, lower, upper);
            Assert.That(results.Count(), Is.EqualTo(11));
            Assert.That(results.First().Position, Is.EqualTo(0d).Within(0.001d));
            Assert.That(results.Last().Position, Is.EqualTo(1d).Within(0.001d));
        }
    }
}
