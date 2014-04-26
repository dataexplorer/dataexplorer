using System;
using System.Linq;
using DataExplorer.Application.Views.ScatterPlots.Axes.Factories.DateTimeGridLines;
using DataExplorer.Domain.Maps.AxisMaps;
using NUnit.Framework;

namespace DataExplorer.Application.Tests.Views.ScatterPlots.Axes.Factories.DateTimeGridLines
{
    [TestFixture]
    public class MinMaxDateTimeAxisGridLineFactoryTests
    {
        private MinMaxDateTimeAxisGridLineFactory _factory;
        private AxisMap _map;

        [SetUp]
        public void SetUp()
        {
            _map = new DateTimeToAxisMap(DateTime.MinValue, DateTime.MaxValue, 0d, 1d, false);

            _factory = new MinMaxDateTimeAxisGridLineFactory();
        }

        [Test]
        public void TestCreateMinShouldReturnMinLine()
        {
            var results = _factory.Create(_map).ToList();
            Assert.That(results.First().LabelName, Is.EqualTo("0001"));
            Assert.That(results.First().Position, Is.EqualTo(0d));
        }

        [Test]
        public void TestCreateMaxShouldReturnMaxLine()
        {
            var results = _factory.Create(_map).ToList();
            Assert.That(results.Last().LabelName, Is.EqualTo("10000"));
            Assert.That(results.Last().Position, Is.EqualTo(1d));
        }
    }
}
