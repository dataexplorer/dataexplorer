using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DataExplorer.Domain.Colors;
using DataExplorer.Domain.Tests.Colors;
using DataExplorer.Domain.Views.ScatterPlots;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Domain.Tests.Views.ScatterPlots
{
    [TestFixture]
    public class ScatterPlotFactoryTests
    {
        private ScatterPlotFactory _factory;
        private Mock<IColorPaletteFactory> _mockColorFactory;
        private ColorPalette _colorPalette;

        [SetUp]
        public void SetUp()
        {
            _colorPalette = new ColorPaletteBuilder().Build();

            _mockColorFactory = new Mock<IColorPaletteFactory>();
            _mockColorFactory.Setup(p => p.GetColorPalette("Pastel 1"))
                .Returns(_colorPalette);

            _factory = new ScatterPlotFactory(
                _mockColorFactory.Object);
        }

        [Test]
        public void TestCreateShouldCreateScatterPlotWithDefaults()
        {
            var result = _factory.Create();
            Assert.That(result.GetViewExtent(), Is.EqualTo(new Rect(-0.1, -0.1, 1.2, 1.2)));
            Assert.That(result.GetPlots(), Is.Empty);
            Assert.That(result.GetLayout().ColorPalette, Is.EqualTo(_colorPalette));
        }
    }
}
