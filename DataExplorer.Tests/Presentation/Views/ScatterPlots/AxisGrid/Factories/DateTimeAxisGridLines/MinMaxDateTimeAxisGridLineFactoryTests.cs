using System;
using System.Linq;
using DataExplorer.Domain.Maps;
using DataExplorer.Domain.Maps.AxisMaps;
using DataExplorer.Presentation.Views.ScatterPlots.AxisGrid.Factories.DateTimeAxisGridLines;
using NUnit.Framework;

namespace DataExplorer.Tests.Presentation.Views.ScatterPlots.AxisGrid.Factories.DateTimeAxisGridLines
{
    [TestFixture]
    public class MinMaxDateTimeAxisGridLineFactoryTests
    {
        private MinMaxDateTimeAxisGridLineFactory _factory;
        private IAxisMap _map;

        [SetUp]
        public void SetUp()
        {
            _map = new DateTimeToAxisMap(DateTime.MinValue, DateTime.MaxValue, 0d, 1d);

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
