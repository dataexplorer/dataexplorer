using System;
using System.Collections.Generic;
using System.Linq;
using DataExplorer.Domain.Maps.AxisMaps;
using DataExplorer.Domain.Views.ScatterPlots;
using DataExplorer.Presentation.Views.ScatterPlots.Grid.Factories.DateTimeGridLines;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Presentation.Tests.Views.ScatterPlots.Grid.Factories.DateTimeGridLines
{
    [TestFixture]
    public class DateTimeAxisGridLineFactoryTests
    {
        private DateTimeGridLineFactory _factory;
        private Mock<IMinMaxDateTimeAxisGridLineFactory> _mockMinMaxFactory;
        private Mock<IYearAxisGridLineFactory> _mockYearFactory;
        private Mock<IDayAxisGridLineFactory> _mockDayFactory;
        private Mock<ISecondAxisGridLineFactory> _mockSecondFactory;
        private List<AxisGridLine> _lines;
        private AxisGridLine _line;
        
        [SetUp]
        public void SetUp()
        {
            _line = new AxisGridLine();
            _lines = new List<AxisGridLine> { _line };

            _mockMinMaxFactory = new Mock<IMinMaxDateTimeAxisGridLineFactory>();
            
            _mockYearFactory = new Mock<IYearAxisGridLineFactory>();
            
            _mockDayFactory = new Mock<IDayAxisGridLineFactory>();

            _mockSecondFactory = new Mock<ISecondAxisGridLineFactory>();

            _factory = new DateTimeGridLineFactory(
                _mockMinMaxFactory.Object,
                _mockYearFactory.Object,
                _mockDayFactory.Object,
                _mockSecondFactory.Object);
        }

        [Test]
        public void TestCreateShouldReturnMinMaxLabels()
        {
            var map = new DateTimeToAxisMap(DateTime.MinValue, DateTime.MaxValue, 0d, 1d);
            _mockMinMaxFactory.Setup(p => p.Create(map)).Returns(_lines);
            var results = _factory.Create(map, -0.1d, 1.1d);
            Assert.That(results.Single(), Is.EqualTo(_line));
        }

        [Test]
        [TestCase(9997, 1000)]
        [TestCase(1001, 1000)]
        [TestCase(1000, 100)]
        [TestCase(101, 100)]
        [TestCase(100, 10)]
        [TestCase(11, 10)]
        [TestCase(10, 1)]
        [TestCase(2, 1)]
        public void TestCreateShouldReturnCorrectYearLines(int years, int step)
        {
            var lower = DateTime.MinValue;
            var upper = lower.AddYears(years);
            var map = new DateTimeToAxisMap(lower, upper, 0d, 1d);
            _mockYearFactory.Setup(p => p.Create(map, It.IsAny<DateTime>(), It.IsAny<DateTime>(), step)).Returns(_lines);
            var results = _factory.Create(map, 0d, 1d);
            Assert.That(results.Single(), Is.EqualTo(_line));
        }

        [Test]
        [TestCase(365)]
        [TestCase(91)]
        public void TestCreateShouldReturnQuarterYearLines(int days)
        {
            var lower = DateTime.MinValue;
            var upper = lower.AddDays(days);
            var map = new DateTimeToAxisMap(lower, upper, 0d, 1d);
            _mockDayFactory.Setup(p => p.CreateQuarters(map, It.IsAny<DateTime>(), It.IsAny<DateTime>())).Returns(_lines);
            var results = _factory.Create(map, 0d, 1d);
            Assert.That(results.Single(), Is.EqualTo(_line));
        }

        [Test]
        [TestCase(90)]
        [TestCase(31)]
        public void TestCreateShouldReturnMonthLines(int days)
        {
            var lower = DateTime.MinValue;
            var upper = lower.AddDays(days);
            var map = new DateTimeToAxisMap(lower, upper, 0d, 1d);
            _mockDayFactory.Setup(p => p.CreateMonths(map, It.IsAny<DateTime>(), It.IsAny<DateTime>())).Returns(_lines);
            var results = _factory.Create(map, 0d, 1d);
            Assert.That(results.Single(), Is.EqualTo(_line));
        }

        [Test]
        [TestCase(30)]
        [TestCase(8)]
        public void TestCreateShouldReturnWeekLines(int days)
        {
            var lower = DateTime.MinValue;
            var upper = lower.AddDays(days);
            var map = new DateTimeToAxisMap(lower, upper, 0d, 1d);
            _mockDayFactory.Setup(p => p.CreateWeeks(map, It.IsAny<DateTime>(), It.IsAny<DateTime>())).Returns(_lines);
            var results = _factory.Create(map, 0d, 1d);
            Assert.That(results.Single(), Is.EqualTo(_line));
        }

        [Test]
        [TestCase(7)]
        [TestCase(2)]
        public void TestCreateShouldReturnDayLines(int days)
        {
            var lower = DateTime.MinValue;
            var upper = lower.AddDays(days);
            var map = new DateTimeToAxisMap(lower, upper, 0d, 1d);
            _mockDayFactory.Setup(p => p.CreateDays(map, It.IsAny<DateTime>(), It.IsAny<DateTime>())).Returns(_lines);
            var results = _factory.Create(map, 0d, 1d);
            Assert.That(results.Single(), Is.EqualTo(_line));
        }

        [Test]
        [TestCase(86400)]
        [TestCase(14401)]
        public void TestCreateShouldReturnQuarterDayLines(int seconds)
        {
            var lower = DateTime.MinValue;
            var upper = lower.AddSeconds(seconds);
            var map = new DateTimeToAxisMap(lower, upper, 0d, 1d);
            _mockSecondFactory.Setup(p => p.CreateFourHours(map, It.IsAny<DateTime>(), It.IsAny<DateTime>())).Returns(_lines);
            var results = _factory.Create(map, 0d, 1d);
            Assert.That(results.Single(), Is.EqualTo(_line));
        }

        [Test]
        [TestCase(14400)]
        [TestCase(3601)]
        public void TestCreateShouldReturnHourLines(int seconds)
        {
            var lower = DateTime.MinValue;
            var upper = lower.AddSeconds(seconds);
            var map = new DateTimeToAxisMap(lower, upper, 0d, 1d);
            _mockSecondFactory.Setup(p => p.CreateHours(map, It.IsAny<DateTime>(), It.IsAny<DateTime>())).Returns(_lines);
            var results = _factory.Create(map, 0d, 1d);
            Assert.That(results.Single(), Is.EqualTo(_line));
        }

        [Test]
        [TestCase(3600)]
        [TestCase(601)]
        public void TestCreateShouldReturnQuarterHourLines(int seconds)
        {
            var lower = DateTime.MinValue;
            var upper = lower.AddSeconds(seconds);
            var map = new DateTimeToAxisMap(lower, upper, 0d, 1d);
            _mockSecondFactory.Setup(p => p.CreateTenMinutes(map, It.IsAny<DateTime>(), It.IsAny<DateTime>())).Returns(_lines);
            var results = _factory.Create(map, 0d, 1d);
            Assert.That(results.Single(), Is.EqualTo(_line));
        }

        [Test]
        [TestCase(600)]
        [TestCase(61)]
        public void TestCreateShouldReturnMinuteLines(int seconds)
        {
            var lower = DateTime.MinValue;
            var upper = lower.AddSeconds(seconds);
            var map = new DateTimeToAxisMap(lower, upper, 0d, 1d);
            _mockSecondFactory.Setup(p => p.CreateMinutes(map, It.IsAny<DateTime>(), It.IsAny<DateTime>())).Returns(_lines);
            var results = _factory.Create(map, 0d, 1d);
            Assert.That(results.Single(), Is.EqualTo(_line));
        }

        [Test]
        [TestCase(60)]
        [TestCase(11)]
        public void TestCreateShouldReturnQuarterMinuteLines(int seconds)
        {
            var lower = DateTime.MinValue;
            var upper = lower.AddSeconds(seconds);
            var map = new DateTimeToAxisMap(lower, upper, 0d, 1d);
            _mockSecondFactory.Setup(p => p.CreateTenSeconds(map, It.IsAny<DateTime>(), It.IsAny<DateTime>())).Returns(_lines);
            var results = _factory.Create(map, 0d, 1d);
            Assert.That(results.Single(), Is.EqualTo(_line));
        }

        [Test]
        [TestCase(10)]
        [TestCase(2)]
        public void TestCreateShouldReturnCorrectSecondLines(int seconds)
        {
            var lower = DateTime.MinValue;
            var upper = lower.AddSeconds(seconds);
            var map = new DateTimeToAxisMap(lower, upper, 0d, 1d);
            _mockSecondFactory.Setup(p => p.CreateSeconds(map, It.IsAny<DateTime>(), It.IsAny<DateTime>())).Returns(_lines);
            var results = _factory.Create(map, 0d, 1d);
            Assert.That(results.Single(), Is.EqualTo(_line));
        }
    }
}
