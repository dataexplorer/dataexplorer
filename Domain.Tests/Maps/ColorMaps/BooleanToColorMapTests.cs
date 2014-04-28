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
    public class BooleanToColorMapTests
    {
        private BooleanToColorMap _map;
        private ColorPalette _colorPalette;
        //private Color _nullColor;

        [SetUp]
        public void SetUp()
        {
            //_nullColor = new Color(127, 127, 127);

             _colorPalette = new ColorPaletteBuilder()
                 .WithColor(Color.FromRgb(255, 0, 0))
                 .WithColor(Color.FromRgb(0, 255, 0))
                 .WithColor(Color.FromRgb(0, 0, 255))
                 .Build();

            _map = new BooleanToColorMap(
                _colorPalette.Colors,
                SortOrder.Ascending);
        }

        [Test]
        [TestCase(null, 127, 127, 127)]
        [TestCase(false, 255, 0, 0)]
        [TestCase(true, 0, 0, 255)]
        public void TestMapShouldReturnCorrectValues(bool? value, byte red, byte green, byte blue)
        {
            var result = _map.Map(value);
            var color = new Color(red, green, blue);
            Assert.That(result, Is.EqualTo(color));
        }

        [Test]
        [TestCase(null, 127, 127, 127)]
        [TestCase(false, 0, 0, 255)]
        [TestCase(true, 255, 0, 0)]
        public void TestMapShouldReturnDescendingValues(bool? value, byte red, byte green, byte blue)
        {
            _map = new BooleanToColorMap(_colorPalette.Colors, SortOrder.Descending);
            var result = _map.Map(value);
            var color = new Color(red, green, blue);
            Assert.That(result, Is.EqualTo(color));
        }

        [Test]
        //[TestCase(null, 127, 127, 127)]
        [TestCase(false, 255, 0, 0)]
        [TestCase(true, 0, 0, 255)]
        public void TestMapInverseShouldReturnCorrectValues(bool? value, byte red, byte green, byte blue)
        {
            var color = new Color(red, green, blue);
            var result = _map.MapInverse(color);
            Assert.That(result, Is.EqualTo(value));
        }

        [Test]
        //[TestCase(null, 127, 127, 127)]
        [TestCase(false, 0, 0, 255)]
        [TestCase(true, 255, 0, 0)]
        public void TestMapInverseShouldReturnDescendingValues(bool? value, byte red, byte green, byte blue)
        {
            _map = new BooleanToColorMap(_colorPalette.Colors, SortOrder.Descending);
            var color = new Color(red, green, blue);
            var result = _map.MapInverse(color);
            Assert.That(result, Is.EqualTo(value));
        }
    }
}
