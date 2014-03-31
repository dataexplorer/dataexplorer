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
        private StringToColorMap _map;
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
                .WithColor(Color.FromRgb(255, 255, 255))
                .Build();

            _map = new StringToColorMap(_sourceValues, _colorPalette.Colors);
        }

        [Test]
        [TestCase(null, 127, 127, 127)]
        [TestCase("A", 255, 0, 0)]
        [TestCase("Z", 0, 0, 255)]
        public void TestMapShouldReturnCorrectValuesWithTwoValues(string value, byte red, byte green, byte blue)
        {
            _sourceValues = new List<string> { "A", "Z" };

            _map = new StringToColorMap(_sourceValues, _colorPalette.Colors);

            var color = new Color(red, green, blue);
            var result = _map.Map(value);
            Assert.That(result, Is.EqualTo(color));
        }

        [Test]
        [TestCase(null, 127, 127, 127)]
        [TestCase("A", 255, 0, 0)]
        [TestCase("M", 0, 255, 0)]
        [TestCase("Z", 0, 0, 255)]
        public void TestMapShouldReturnCorrectValuesWithThreeValues(string value, byte red, byte green, byte blue)
        {
            _sourceValues = new List<string> { "A", "M", "Z" };

            _map = new StringToColorMap(_sourceValues, _colorPalette.Colors);

            var color = new Color(red, green, blue);
            var result = _map.Map(value);
            Assert.That(result, Is.EqualTo(color));
        }

        [Test]
        [TestCase(null, 127, 127, 127)]
        [TestCase("A", 255, 0, 0)]
        [TestCase("B", 0, 255, 0)]
        [TestCase("C", 0, 0, 255)]
        [TestCase("D", 255, 255, 255)]
        public void TestMapShouldReturnCorrectValuesWithFourValues(string value, byte red, byte green, byte blue)
        {
            _sourceValues = new List<string> { "A", "B", "C", "D" };

            _map = new StringToColorMap(_sourceValues, _colorPalette.Colors);

            var color = new Color(red, green, blue);
            var result = _map.Map(value);
            Assert.That(result, Is.EqualTo(color));
        }

        [Test]
        [TestCase(null, 127, 127, 127)]
        [TestCase("A", 255, 0, 0)]
        [TestCase("B", 255, 0, 0)]
        [TestCase("C", 0, 255, 0)]
        [TestCase("D", 0, 0, 255)]
        [TestCase("E", 255, 255, 255)]
        public void TestMapShouldReturnCorrectValuesWithFiveValues(string value, byte red, byte green, byte blue)
        {
            _sourceValues = new List<string> { "A", "B", "C", "D", "E" };

            _map = new StringToColorMap(_sourceValues, _colorPalette.Colors);

            var color = new Color(red, green, blue);
            var result = _map.Map(value);
            Assert.That(result, Is.EqualTo(color));
        }

        [Test]
        //[TestCase(null, 127, 127, 127)]
        [TestCase("A", 255, 0, 0)]
        [TestCase("Z", 0, 0, 255)]
        public void TestMapInverseShouldReturnCorrectValuesWithTwoValues(string value, byte red, byte green, byte blue)
        {
            _sourceValues = new List<string> { "A", "Z" };

            _map = new StringToColorMap(_sourceValues, _colorPalette.Colors);

            var color = new Color(red, green, blue);
            var result = _map.MapInverse(color);
            Assert.That(result, Is.EqualTo(value));
        }

        [Test]
        //[TestCase(null, 127, 127, 127)]
        [TestCase("A", 255, 0, 0)]
        [TestCase("M", 0, 255, 0)]
        [TestCase("Z", 0, 0, 255)]
        public void TestMapInverseShouldReturnCorrectValuesWithThreeValues(string value, byte red, byte green, byte blue)
        {
            _sourceValues = new List<string> { "A", "M", "Z" };

            _map = new StringToColorMap(_sourceValues, _colorPalette.Colors);

            var color = new Color(red, green, blue);
            var result = _map.MapInverse(color);
            Assert.That(result, Is.EqualTo(value));
        }

        [Test]
        //[TestCase(null, 127, 127, 127)]
        [TestCase("A", 255, 0, 0)]
        [TestCase("B", 0, 255, 0)]
        [TestCase("C", 0, 0, 255)]
        [TestCase("D", 255, 255, 255)]
        public void TestMapInverseShouldReturnCorrectValuesWithFourValues(string value, byte red, byte green, byte blue)
        {
            _sourceValues = new List<string> { "A", "B", "C", "D" };

            _map = new StringToColorMap(_sourceValues, _colorPalette.Colors);

            var color = new Color(red, green, blue);
            var result = _map.MapInverse(color);
            Assert.That(result, Is.EqualTo(value));
        }

        [Test]
        //[TestCase(null, 127, 127, 127)]
        [TestCase("A", 255, 0, 0)]
        [TestCase("B", 0, 255, 0)]
        [TestCase("C", 0, 0, 255)]
        [TestCase("D", 255, 255, 255)]
        public void TestMapInverseShouldReturnCorrectValuesWithFiveValues(string value, byte red, byte green, byte blue)
        {
            _sourceValues = new List<string> { "A", "B", "C", "D" };

            _map = new StringToColorMap(_sourceValues, _colorPalette.Colors);

            var color = new Color(red, green, blue);
            var result = _map.MapInverse(color);
            Assert.That(result, Is.EqualTo(value));
        }
    }
}
