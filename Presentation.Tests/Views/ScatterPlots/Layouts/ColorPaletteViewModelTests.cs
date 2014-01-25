using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using DataExplorer.Domain;
using DataExplorer.Domain.Tests.Colors;
using DataExplorer.Presentation.Views.ScatterPlots.Layout.Color;
using NUnit.Framework;

namespace DataExplorer.Presentation.Tests.Views.ScatterPlots.Layouts
{
    [TestFixture]
    public class ColorPaletteViewModelTests
    {
        private ColorPaletteViewModel _viewModel;
        private ColorPalette _colorPalette;
        private Domain.Colors.Color _color;
 
        [SetUp]
        public void SetUp()
        {
            _color = new Domain.Colors.Color(255, 255, 255);

            _colorPalette = new ColorPaletteBuilder().WithColor(_color).Build();

            _viewModel = new ColorPaletteViewModel(_colorPalette);
        }

        [Test]
        public void TestColorsShouldReturnColors()
        {
            var result = _viewModel.Colors;

            Assert.That(result.Single(), Is.EqualTo(Colors.White));

        }

        [Test]
        public void TestGetColorPaletteShouldReturnColorPalette()
        {
            var result = _viewModel.ColorPalette;

            Assert.That(result, Is.EqualTo(_colorPalette));
        }

        
    }
}
