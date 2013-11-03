using System.Linq;
using DataExplorer.Domain.Maps;
using DataExplorer.Domain.Maps.AxisMaps;
using DataExplorer.Presentation.Views.ScatterPlots.AxisGridLines.Factories.BooleanAxisGridLines;
using NUnit.Framework;

namespace DataExplorer.Tests.Presentation.Views.ScatterPlots.AxisGridLines.Factories.BooleanAxisGridLines
{
    [TestFixture]
    public class BooleanAxisGridLineFactoryTests
    {
        private BooleanAxisGridLineFactory _factory;
        private IAxisMap _map;

        [SetUp]
        public void SetUp()
        {
            _map = new BooleanToAxisMap(0d, 1d);

            _factory = new BooleanAxisGridLineFactory();
        }

        [Test]
        public void TestCreateShouldReturnFalseGridLine()
        {
            var results = _factory.Create(_map, 0d, 1d);
            Assert.That(results.First().Position, Is.EqualTo(0d));
        }

        [Test]
        public void TestCreateShouldReturnTrueGridLine()
        {
            var results = _factory.Create(_map, 0d, 1d);
            Assert.That(results.Last().Position, Is.EqualTo(1d));
        }
    }
}
