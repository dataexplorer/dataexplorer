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
            var results = _factory.Create(_map);
            Assert.That(results.First().Position, Is.EqualTo(0d));
        }

        [Test]
        public void TestCreateMaxShouldReturnMaxLine()
        {
            var results = _factory.Create(_map);
            Assert.That(results.Last().Position, Is.EqualTo(1d));
        }
    }
}
