using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Legends.Colors.Factories;
using DataExplorer.Domain.Colors;
using DataExplorer.Domain.Maps.ColorMaps;
using DataExplorer.Domain.Tests.Colors;
using DataExplorer.Domain.Tests.Maps;
using DataExplorer.Domain.Tests.Maps.ColorMaps;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Application.Tests.Legends.Colors.Factories
{
    [TestFixture]
    public class ColorLegendFactoryTests
    {
        private ColorLegendFactory _factory;
        private Mock<IBooleanColorLegendFactory> _mockBooleanFactory;
        private Mock<IDateTimeColorLegendFactory> _mockDateTimeFactory;
        private Mock<IFloatColorLegendFactory> _mockFloatFactory;
        private Mock<IIntegerColorLegendFactory> _mockIntegerFactory;
        private Mock<IStringColorLegendFactory> _mockStringFactory;

        private ColorMap _colorMap;
        private List<object> _values;
        private ColorPalette _palette;
        
            
        [SetUp]
        public void SetUp()
        {
            _colorMap = new FakeColorMap();
            _values = new List<object>();
            _palette = new ColorPaletteBuilder().Build();

            _mockBooleanFactory = new Mock<IBooleanColorLegendFactory>();
            _mockDateTimeFactory = new Mock<IDateTimeColorLegendFactory>();
            _mockFloatFactory = new Mock<IFloatColorLegendFactory>();
            _mockIntegerFactory = new Mock<IIntegerColorLegendFactory>();
            _mockStringFactory = new Mock<IStringColorLegendFactory>();

            _factory = new ColorLegendFactory(
                _mockBooleanFactory.Object,
                _mockDateTimeFactory.Object,
                _mockFloatFactory.Object,
                _mockIntegerFactory.Object,
                _mockStringFactory.Object);
        }

        [Test]
        public void TestCreateBooleanColorLegendItems()
        {
            _factory.Create(typeof(Boolean), _colorMap, _values, _palette);
            _mockBooleanFactory.Verify(p => p.Create(_colorMap, It.IsAny<List<bool?>>(), _palette), Times.Once());
        }

        [Test]
        public void TestCreateDateTimeColorLegendItems()
        {
            _factory.Create(typeof(DateTime), _colorMap, _values, _palette);
            _mockDateTimeFactory.Verify(p => p.Create(_colorMap, It.IsAny<List<DateTime?>>(), _palette), Times.Once());
        }

        [Test]
        public void TestCreateFloatColorLegendItems()
        {
            _factory.Create(typeof(Double), _colorMap, _values, _palette);
            _mockFloatFactory.Verify(p => p.Create(_colorMap, It.IsAny<List<double?>>(), _palette), Times.Once());
        }

        [Test]
        public void TestCreateIntegerColorLegendItems()
        {
            _factory.Create(typeof(Int32), _colorMap, _values, _palette);
            _mockIntegerFactory.Verify(p => p.Create(_colorMap, It.IsAny<List<int?>>(), _palette), Times.Once());
        }

        [Test]
        public void TestCreateStringColorLegendItems()
        {
            _factory.Create(typeof(String), _colorMap, _values, _palette);
            _mockStringFactory.Verify(p => p.Create(_colorMap, It.IsAny<List<string>>(), _palette), Times.Once());
        }
    }
}
