using System.Linq;
using DataExplorer.Domain.Maps;
using DataExplorer.Domain.Maps.AxisMaps;
using DataExplorer.Presentation.Views.ScatterPlots.Grid.Factories.BooleanGridLines;
using NUnit.Framework;

namespace DataExplorer.Presentation.Tests.Views.ScatterPlots.Grid.Factories.BooleanGridLines
{
    [TestFixture]
    public class BooleanAxisGridLineFactoryTests
    {
        private BooleanGridLineFactory _factory;
        private IAxisMap _map;

        [SetUp]
        public void SetUp()
        {
            _map = new BooleanToAxisMap(0d, 1d);

            _factory = new BooleanGridLineFactory();
        }

        [Test]
        public void TestCreateShouldReturnFalseGridLine()
        {
            var results = _factory.Create(_map, 0d, 1d);
            Assert.That(results.First().LabelName, Is.EqualTo("False"));
            Assert.That(results.First().Position, Is.EqualTo(0d));
        }

        [Test]
        public void TestCreateShouldReturnTrueGridLine()
        {
            var results = _factory.Create(_map, 0d, 1d);
            Assert.That(results.Last().LabelName, Is.EqualTo("True"));
            Assert.That(results.Last().Position, Is.EqualTo(1d));
        }
    }
}
