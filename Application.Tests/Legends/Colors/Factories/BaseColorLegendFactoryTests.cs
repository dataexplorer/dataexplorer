using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Legends;
using DataExplorer.Application.Legends.Colors;
using DataExplorer.Application.Legends.Colors.Factories;
using DataExplorer.Domain.Colors;
using DataExplorer.Domain.Maps.ColorMaps;
using DataExplorer.Domain.Tests.Colors;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Application.Tests.Legends.Colors.Factories
{
    [TestFixture]
    public class BaseColorLegendFactoryTests
    {
        private FakeColorLegendFactory _factory;
        private Mock<ColorMap> _mockColorMap;
        private List<int?> _values;
        private ColorPalette _palette;
        private Color _color1;

        [SetUp]
        public void SetUp()
        {
            _values = new List<int?>();
            _color1 = new Color(255, 0, 0);
            _palette = new ColorPaletteBuilder().Build();

            _mockColorMap = new Mock<ColorMap>();
            _mockColorMap.Setup(p => p.Map(It.IsAny<int?>()))
                .Returns(_color1);
            _mockColorMap.Setup(p => p.MapInverse(It.IsAny<Color>()))
                .Returns(0);

            _factory = new FakeColorLegendFactory();
        }

        [Test]
        public void TestCreateShouldCreateNullValueIfNullsExist()
        {
            var nullColor = new Color(127, 127, 127);
            _palette.Colors.Add(nullColor);
            _values.Add(null);
            var result = _factory.GetNullColorLegendItem();
            Assert.That(result.Color, Is.EqualTo(nullColor));
            Assert.That(result.Label, Is.EqualTo("Null"));
        }

        private class FakeColorLegendFactory : BaseColorLegendFactory
        {
            public ColorLegendItemDto GetNullColorLegendItem()
            {
                return CreateNullColorLegendItem();
            }
        }
    }
}
