using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Colors;
using DataExplorer.Domain.Layouts;
using DataExplorer.Domain.Maps.ColorMaps;
using DataExplorer.Domain.Tests.Colors;
using NUnit.Framework;

namespace DataExplorer.Domain.Tests.Maps.ColorMaps
{
    [TestFixture]
    public class IntegerToColorMapTests
    {
        private IntegerToColorMap _map;
        private ColorPalette _colorPalette;

        [SetUp]
        public void SetUp()
        {
            _colorPalette = new ColorPaletteBuilder()
                .WithColor(Color.FromRgb(255, 0, 0))
                .WithColor(Color.FromRgb(0, 255, 0))
                .WithColor(Color.FromRgb(0, 0, 255))
                .Build();

            _map = new IntegerToColorMap(-10, 10, _colorPalette.Colors, SortOrder.Ascending);
        }

        [Test]
        [TestCase(null, 127, 127, 127)]
        [TestCase(-10, 255, 0, 0)]
        [TestCase(0, 0, 255, 0)]
        [TestCase(10, 0, 0, 255)]
        public void TestMapShouldReturnCorrectValues(int? value, byte red, byte green, byte blue)
        {
            var color = new Color(red, green, blue);
            var result = _map.Map(value);
            Assert.That(result, Is.EqualTo(color));
        }

        [Test]
        [TestCase(null, 127, 127, 127)]
        [TestCase(-10, 0, 0, 255)]
        [TestCase(0, 0, 255, 0)]
        [TestCase(10, 255, 0, 0)]
        public void TestMapShouldReturnDescendingValues(int? value, byte red, byte green, byte blue)
        {
            _map = new IntegerToColorMap(-10, 10, _colorPalette.Colors, SortOrder.Descending);
            var color = new Color(red, green, blue);
            var result = _map.Map(value);
            Assert.That(result, Is.EqualTo(color));
        }

        [Test]
        //[TestCase(null, 127, 127, 127)]
        [TestCase(-10, 255, 0, 0)]
        [TestCase(0, 0, 255, 0)]
        [TestCase(10, 0, 0, 255)]
        public void TestMapInverseShouldReturnCorrectValues(int? value, byte red, byte green, byte blue)
        {
            var color = new Color(red, green, blue);
            var result = _map.MapInverse(color);
            Assert.That(result, Is.EqualTo(value));
        }

        [Test]
        //[TestCase(null, 127, 127, 127)]
        [TestCase(-10, 0, 0, 255)]
        [TestCase(0, 0, 255, 0)]
        [TestCase(10, 255, 0, 0)]
        public void TestMapInverseShouldReturnDescendingValues(int? value, byte red, byte green, byte blue)
        {
            _map = new IntegerToColorMap(-10, 10, _colorPalette.Colors, SortOrder.Descending);
            var color = new Color(red, green, blue);
            var result = _map.MapInverse(color);
            Assert.That(result, Is.EqualTo(value));
        }
    }
}
