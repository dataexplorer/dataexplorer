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
    public class DateTimeToColorMapTests
    {
        private DateTimeToColorMap _map;
        private ColorPalette _colorPalette;
        private Color _nullColor;

        [SetUp]
        public void SetUp()
        {
            _nullColor = new Color(127, 127, 127);

            _colorPalette = new ColorPaletteBuilder()
                .WithColor(Color.FromRgb(255, 0, 0))
                .WithColor(Color.FromRgb(0, 255, 0))
                .WithColor(Color.FromRgb(0, 0, 255))
                .Build();

            _map = new DateTimeToColorMap(
                DateTime.MinValue,
                DateTime.MaxValue,
                _colorPalette.Colors);
        }

        [Test]
        public void TestMapShouldHandleNullValue()
        {
            var result = _map.Map(null);
            Assert.That(result, Is.EqualTo(_nullColor));
        }

        [Test]
        [TestCase("1/1/0001", 255, 0, 0)]
        [TestCase("7/2/5000", 0, 255, 0)]
        [TestCase("12/31/9999", 0, 0, 255)]
        public void TestMapShouldReturnCorrectValues(string date, byte red, byte green, byte blue)
        {
            var color = new Color(red, green, blue);
            var value = DateTime.Parse(date);
            var result = _map.Map(value);
            Assert.That(result, Is.EqualTo(color));
        }

        [Test]
        [TestCase("1/1/0001", 255, 0, 0)]
        [TestCase("7/2/5000", 0, 255, 0)]
        [TestCase("12/31/9999", 0, 0, 255)]
        public void TestMapInverseShouldReturnCorrectValues(string date, byte red, byte green, byte blue)
        {
            var color = new Color(red, green, blue);
            var value = DateTime.Parse(date);
            var result = _map.MapInverse(color);
            Assert.That(((DateTime) result).Date, Is.EqualTo(value.Date));
        }
    }
}
