using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Colors;
using NUnit.Framework;

namespace DataExplorer.Domain.Tests.Colors
{
    [TestFixture]
    public class ColorPaletteTests
    {
        private ColorPalette _palette;
        private List<Color> _colors;
        private Color _color;

        [SetUp]
        public void SetUp()
        {
            _color = new Color(1, 2, 3);

            _colors = new List<Color>() { _color };

            _palette = new ColorPalette("Test", _colors);
        }

        [Test]
        public void TestConstructorShouldSetName()
        {
            Assert.That(_palette.Name, Is.EqualTo("Test"));
        }

        [Test]
        public void TestConstructorShouldSetColors()
        {
            Assert.That(_palette.Colors.Single(), Is.EqualTo(_color));
        }
    }
}
