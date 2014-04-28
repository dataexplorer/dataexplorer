using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Legends.Colors.Factories;
using DataExplorer.Domain.Colors;
using DataExplorer.Domain.Layouts;
using DataExplorer.Domain.Maps.ColorMaps;
using DataExplorer.Domain.Tests.Colors;
using DataExplorer.Domain.Tests.Maps.ColorMaps;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Application.Tests.Legends.Colors.Factories
{
    [TestFixture]
    public class StringColorLegendFactoryTests
    {
        private StringColorLegendFactory _factory;
        private FakeColorMap _colorMap;
        private List<string> _values;
        private ColorPalette _palette;
        private Color _color1;

        [SetUp]
        public void SetUp()
        {
            _values = new List<string>();
            _color1 = new Color(255, 0, 0);
            _palette = new ColorPaletteBuilder().Build();

            _colorMap = new FakeColorMap(SortOrder.Ascending, _color1, string.Empty);
            
            _factory = new StringColorLegendFactory();
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

        [Test]
        public void TestCreateShouldCreateDiscreteItemsInDescendingOrder()
        {
            _colorMap = new FakeColorMap(SortOrder.Descending, _color1, string.Empty);
            AssertResult(16, 8, 8);
        }
        
        private void AssertResult(int valueCount, int colorCount, int itemCount)
        {
            for (var i = 0; i < colorCount; i++)
                _palette.Colors.Add(_color1);

            for (var i = 0; i < valueCount; i++)
                _values.Add(Convert.ToChar(65 + i).ToString());

            var results = _factory.Create(_colorMap, _values, _palette);
            Assert.That(results.Count(), Is.EqualTo(itemCount));
        }
    }
}
