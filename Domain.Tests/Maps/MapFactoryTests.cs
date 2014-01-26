using System;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Maps;
using DataExplorer.Domain.Maps.AxisMaps;
using DataExplorer.Domain.Tests.Columns;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Domain.Tests.Maps
{
    [TestFixture]
    public class MapFactoryTests
    {
        private MapFactory _factory;
        private Mock<IAxisMapFactory> _mockAxisMapFactory;
        private Column _column;

        [SetUp]
        public void SetUp()
        {
            _column = new ColumnBuilder().Build();

            _mockAxisMapFactory = new Mock<IAxisMapFactory>();

            _factory = new MapFactory(
                _mockAxisMapFactory.Object);
        }
        
        [Test]
        public void TestCreateAxisMapForBooleanShouldReturnABooleanToAxisMap()
        {
            _factory.CreateAxisMap(_column, 0d, 1d);
            _mockAxisMapFactory.Verify(p => p.Create(_column, 0d, 1d));
        }
    }
}
