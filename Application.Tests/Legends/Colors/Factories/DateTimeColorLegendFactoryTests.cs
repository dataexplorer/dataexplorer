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
    public class DateTimeColorLegendFactoryTests
    {
        private DateTimeColorLegendFactory _factory;
        private Mock<ColorMap> _mockColorMap;
        private List<DateTime?> _values;
        private ColorPalette _palette;
        private Color _color1;

        [SetUp]
        public void SetUp()
        {
            _values = new List<DateTime?>();
            _color1 = new Color(255, 0, 0);
            _palette = new ColorPaletteBuilder().Build();
            
            _mockColorMap = new Mock<ColorMap>();
            _mockColorMap.Setup(p => p.Map(It.IsAny<DateTime?>()))
                .Returns(_color1);
            _mockColorMap.Setup(p => p.MapInverse(It.IsAny<Color>()))
                .Returns(DateTime.MinValue);
            
            _factory = new DateTimeColorLegendFactory();
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
        
        private void AssertResult(int valueCount, int colorCount, int itemCount)
        {
            for (var i = 0; i < colorCount; i++)
                _palette.Colors.Add(_color1);

            for (var i = 0; i < valueCount; i++)
                _values.Add(DateTime.MinValue.AddDays(i));

            var results = _factory.Create(_mockColorMap.Object, _values, _palette);
            Assert.That(results.Count(), Is.EqualTo(itemCount));
            Assert.That(results.First().Color, Is.EqualTo(_palette.Colors.First()));
            Assert.That(results.First().Label, Is.EqualTo(DateTime.MinValue.ToShortDateString()));
            Assert.That(results.Last().Color, Is.EqualTo(_palette.Colors.Last()));
        }
    }
}
