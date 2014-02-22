using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Legends;
using DataExplorer.Application.Legends.Colors.Factories;
using DataExplorer.Domain.Colors;
using DataExplorer.Domain.Maps.ColorMaps;
using DataExplorer.Domain.Tests.Maps;
using NUnit.Framework;

namespace DataExplorer.Application.Tests.Legends.Colors.Factories
{
    [TestFixture]
    public class BooleanColorLegendItemFactoryTests
    {
        private BooleanColorLegendFactory _factory;
        private ColorMap _colorMap;
        private List<bool?> _values;
        private ColorPalette _palette;

        [SetUp]
        public void SetUp()
        {
            _colorMap = new FakeColorMap();
            _values = new List<bool?>();
            _palette = new ColorPaletteFactory().Pastel1;

            _factory = new BooleanColorLegendFactory();
        }
        
        [Test]
        public void TestCreateShouldReturnColorLegendItems()
        {
            var results = _factory.Create(_colorMap, _values, _palette);
            AssertResult(results.First(), _palette.Colors.First(), "False");
            AssertResult(results.Last(), _palette.Colors.Last(), "True");
        }

        private void AssertResult(ColorLegendItemDto itemDto, Color color, string label)
        {
            Assert.That(itemDto.Color, Is.EqualTo(color));
            Assert.That(itemDto.Label, Is.EqualTo(label));
        }
    }
}
