using System;
using DataExplorer.Domain.Colors;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Maps;
using DataExplorer.Domain.Maps.AxisMaps;
using DataExplorer.Domain.Maps.ColorMaps;
using DataExplorer.Domain.Tests.Colors;
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
        private Mock<IColorMapFactory> _mockColorMapFactory;
        private Column _column;
        private ColorPalette _colorPalette;
        private AxisMap _axisMap;
        private ColorMap _colorMap;

        [SetUp]
        public void SetUp()
        {
            _axisMap = new FakeAxisMap();
            _colorMap = new FakeColorMap();

            _column = new ColumnBuilder().Build();
            _colorPalette = new ColorPaletteBuilder().Build();

            _mockAxisMapFactory = new Mock<IAxisMapFactory>();
            _mockAxisMapFactory.Setup(p => p.Create(_column, 0d, 1d))
                .Returns(_axisMap);

            _mockColorMapFactory = new Mock<IColorMapFactory>();
            _mockColorMapFactory.Setup(p => p.Create(_column, _colorPalette)).Returns(_colorMap);
            
            _factory = new MapFactory(
                _mockAxisMapFactory.Object,
                _mockColorMapFactory.Object);
        }
        
        [Test]
        public void TestCreateAxisMapForBooleanShouldReturnABooleanToAxisMap()
        {
            var result = _factory.CreateAxisMap(_column, 0d, 1d);
            
            Assert.That(result, Is.EqualTo(_axisMap));
        }

        [Test]
        public void TestCreateColorMapShouldReturnColorMap()
        {
            var result = _factory.CreateColorMap(_column, _colorPalette);
            
            Assert.That(result, Is.EqualTo(_colorMap));
        }
    }

    public class FakeAxisMap : AxisMap
    {
        public override double? Map(object value)
        {
            throw new NotImplementedException();
        }

        public override object MapInverse(double? value)
        {
            throw new NotImplementedException();
        }
    }

    public class FakeColorMap : ColorMap
    {
        public override Color Map(object value)
        {
            throw new NotImplementedException();
        }

        public override object MapInverse(Color value)
        {
            throw new NotImplementedException();
        }
    }
}
