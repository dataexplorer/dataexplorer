using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Colors;
using DataExplorer.Domain.Maps.ColorMaps;
using DataExplorer.Domain.Tests.Colors;
using NUnit.Framework;

namespace DataExplorer.Domain.Tests.Maps.ColorMaps
{
    [TestFixture]
    public class StringToColorMapTests
    {
        public StringToColorMap _map;
        private List<string> _sourceValues; 
        private ColorPalette _colorPalette;

        [SetUp]
        public void SetUp()
        {
            _sourceValues = new List<string> { "Apple", "Elephant", "Monkey", "Tiger", "Zebra" };

            _colorPalette = new ColorPaletteBuilder()
                .WithColor(Color.FromRgb(255, 0, 0))
                .WithColor(Color.FromRgb(0, 255, 0))
                .WithColor(Color.FromRgb(0, 0, 255))
                .Build();

            _map = new StringToColorMap(_sourceValues, _colorPalette.Colors);
        }

        [Test]
        [TestCase(null, 127, 127, 127)]
        [TestCase("Apple", 255, 0, 0)]
        [TestCase("Monkey", 0, 255, 0)]
        [TestCase("Zebra", 0, 0, 255)]
        public void TestMapShouldReturnCorrectValues(string value, byte red, byte green, byte blue)
        {
            var color = new Color(red, green, blue);
            var result = _map.Map(value);
            Assert.That(result, Is.EqualTo(color));
        }

        [Test]
        //[TestCase(null, 127, 127, 127)]
        [TestCase("Apple", 255, 0, 0)]
        [TestCase("Monkey", 0, 255, 0)]
        [TestCase("Zebra", 0, 0, 255)]
        public void TestMapInverseShouldReturnCorrectValues(string value, byte red, byte green, byte blue)
        {
            var color = new Color(red, green, blue);
            var result = _map.MapInverse(color);
            Assert.That(result, Is.EqualTo(value));
        }
    }
}
