using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Legends.Colors.Factories;
using DataExplorer.Domain.Colors;
using DataExplorer.Domain.Maps.ColorMaps;
using DataExplorer.Domain.Tests.Colors;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Application.Tests.Legends.Colors.Factories
{
    [TestFixture]
    public class FloatColorLegendFactoryTests
    {
        private FloatColorLegendFactory _factory;
        private Mock<ColorMap> _mockColorMap;
        private List<double?> _values;
        private ColorPalette _palette;
        private Color _color1;

        [SetUp]
        public void SetUp()
        {
            _values = new List<double?>();
            _color1 = new Color(255, 0, 0);
            _palette = new ColorPaletteBuilder().Build();

            _mockColorMap = new Mock<ColorMap>();
            _mockColorMap.Setup(p => p.Map(It.IsAny<double?>()))
                .Returns(_color1);
            _mockColorMap.Setup(p => p.MapInverse(It.IsAny<Color>()))
                .Returns(0d);

            _factory = new FloatColorLegendFactory();
        }
        
        [Test]
        public void TestCreateShouldCreateDiscreteItemsIfValuesLessThanColors()
        {
            AssertResult(4, 8, 4);
        }

        [Test]
        public void TestCreateShouldCreateDiscreteItemsIfValuesAreEqualToColors()
        {
            AssertResult(8, 8, 8);
        }

        [Test]
        public void TestCreateShouldCreateDiscreteItemsIfValuesAreGreaterThanColors()
        {
            AssertResult(16, 8, 8);
        }
        
        private void AssertResult(double valueCount, double colorCount, double itemCount)
        {
            for (var i = 0; i < colorCount; i++)
                _palette.Colors.Add(_color1);

            for (var i = 0; i < valueCount; i++)
                _values.Add(i);

            var results = _factory.Create(_mockColorMap.Object, _values, _palette);
            Assert.That(results.Count(), Is.EqualTo(itemCount));
            Assert.That(results.First().Color, Is.EqualTo(_palette.Colors.First()));
            Assert.That(results.First().Label, Is.EqualTo("0.00"));
            Assert.That(results.Last().Color, Is.EqualTo(_palette.Colors.Last()));
        }
    }
}
