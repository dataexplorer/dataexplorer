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
    public class ColorTests
    {
        private Color _color;
        private byte _red;
        private byte _green;
        private byte _blue;

        [SetUp]
        public void SetUp()
        {
            _red = 1;
            _green = 2;
            _blue = 3;

            _color = new Color(_red, _green, _blue);
        }

        [Test]
        public void TestConstructorShouldSetValues()
        {
            Assert.That(_color.Alpha, Is.EqualTo(0));
            Assert.That(_color.Red, Is.EqualTo(_red));
            Assert.That(_color.Green, Is.EqualTo(_green));
            Assert.That(_color.Blue, Is.EqualTo(_blue));
        }

        [Test]
        public void TestFromRgbShouldReturnColor()
        {
            var result = Color.FromRgb(1, 2, 3);
            Assert.That(result, Is.EqualTo(_color));
        }
    }
}
