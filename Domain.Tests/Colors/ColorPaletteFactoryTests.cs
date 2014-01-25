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
    public class ColorPaletteFactoryTests
    {
        private ColorPaletteFactory _factory;

        [SetUp]
        public void SetUp()
        {
            _factory = new ColorPaletteFactory();
        }

        [Test]
        public void TestGetAllColorPalettesShouldReturnAllColorPalettes()
        {
            var results = _factory.GetColorPalettes();
            Assert.That(results.Count(), Is.EqualTo(16));
        }

        [Test]
        public void TestGetPaletteShouldReturnSpecifiedPalette()
        {
            var results = _factory.GetColorPalette("Pastel 1");
            Assert.That(results.Name, Is.EqualTo("Pastel 1"));
        }
    }
}
