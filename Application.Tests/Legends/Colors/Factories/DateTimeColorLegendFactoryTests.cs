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
    public class DateTimeColorLegendFactoryTests
    {
        private DateTimeColorLegendFactory _factory;
        private FakeColorMap _colorMap;
        private List<DateTime?> _values;
        private ColorPalette _palette;
        private Color _color1;

        [SetUp]
        public void SetUp()
        {
            _values = new List<DateTime?>();
            _color1 = new Color(255, 0, 0);
            _palette = new ColorPaletteBuilder().Build();

            _colorMap = new FakeColorMap(SortOrder.Ascending, _color1, new DateTime());
            
            _factory = new DateTimeColorLegendFactory();
        }
        
        [Test]
        public void TestCreateShouldCreateDiscreteItemsIfValuesLessThanColors()
        {
            SetUpTest(4, 8);
            AssertResult(4);
        }

        [Test]
        public void TestCreateShouldCreateDiscreteItemsIfValuesAreEqualToColors()
        {
            SetUpTest(8, 8);
            AssertResult(8);
        }

        [Test]
        public void TestCreateShouldCreateDiscreteItemsIfValuesAreGreaterThanColors()
        {
            SetUpTest(16, 8);
            AssertResult(8);
        }

        private void SetUpTest(int valueCount, int colorCount)
        {
            for (var i = 0; i < colorCount; i++)
                _palette.Colors.Add(_color1);

            for (var i = 0; i < valueCount; i++)
                _values.Add(DateTime.MinValue.AddDays(i));
        }

        private void AssertResult(int itemCount)
        {
            var results = _factory.Create(_colorMap, _values, _palette);
            Assert.That(results.Count(), Is.EqualTo(itemCount));
        }
    }
}
