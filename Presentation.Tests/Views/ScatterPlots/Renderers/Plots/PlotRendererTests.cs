using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using DataExplorer.Application.Views.ScatterPlots;
using DataExplorer.Presentation.Core.Canvas.Factories;
using DataExplorer.Presentation.Core.Canvas.Items;
using DataExplorer.Presentation.Core.Geometry;
using DataExplorer.Presentation.Views.ScatterPlots.Renderers.Plots;
using DataExplorer.Presentation.Views.ScatterPlots.Scalers;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Presentation.Tests.Views.ScatterPlots.Renderers.Plots
{
    [TestFixture]
    public class PlotRendererTests
    {
        private PlotRenderer _renderer;
        private Mock<IViewResizer> _mockResizer;
        private Mock<IScaleComputer> _mockComputer;
        private Mock<IGeometryCalculator> _mockCalculator;
        private Mock<IGeometryFactory> _mockFactory;
        private Size _controlSize;
        private Rect _viewExtent;
        private PlotDto _plot;
        private List<PlotDto> _plots;
        private CanvasCircle _canvasCircle;
        private CanvasImage _canvasImage;
        private CanvasLabel _canvasLabel;

        [SetUp]
        public void SetUp()
        {
            _controlSize = new Size();
            _viewExtent = new Rect();
            _plot = new PlotDto()
            {
                Id = 1, 
                X = 1d, 
                Y = 2d, 
                Color = new Domain.Colors.Color(0, 0, 0),
                Label = "Test",
                Image = new BitmapImage()
            };
            _plots = new List<PlotDto> { _plot };
            _canvasCircle = new CanvasCircle();
            _canvasImage = new CanvasImage();
            _canvasLabel = new CanvasLabel();

            _mockResizer = new Mock<IViewResizer>();
            _mockResizer.Setup(p => p.ResizeView(_controlSize, _viewExtent))
                .Returns(_viewExtent);

            _mockComputer = new Mock<IScaleComputer>();
            _mockComputer.Setup(p => p.ComputeScale(_controlSize, _viewExtent)).Returns(1d);

            _mockCalculator = new Mock<IGeometryCalculator>();

            _mockFactory = new Mock<IGeometryFactory>();
            _mockFactory.Setup(p => p.CreateCircle(_plot.Id, It.IsAny<Rect>(), It.IsAny<Color>()))
                .Returns(_canvasCircle);
            _mockFactory.Setup(p => p.CreateImage(_plot.Id, It.IsAny<Rect>(), _plot.Image))
                .Returns(_canvasImage);
            _mockFactory.Setup(p => p.CreateLabel(_plot.Id, It.IsAny<Point>(), _plot.Label))
                .Returns(_canvasLabel);

            _renderer = new PlotRenderer(
                _mockResizer.Object,
                _mockComputer.Object,
                _mockCalculator.Object,
                _mockFactory.Object);
        }

        [Test]
        public void TestRenderPlotsShouldReturnCircle()
        {
            _plot.Image = null;
            var results = _renderer.RenderPlots(_controlSize, _viewExtent, _plots);
            Assert.That(results, Has.Member(_canvasCircle));
        }

        [Test]
        public void TestRenderPlotsShouldReturnImageIfImageIsPresent()
        {
            var results = _renderer.RenderPlots(_controlSize, _viewExtent, _plots);
            Assert.That(results, Has.Member(_canvasImage));
        }

        [Test]
        public void TestRenderPlotsShouldReturnLabel()
        {
            var results = _renderer.RenderPlots(_controlSize, _viewExtent, _plots);
            Assert.That(results, Has.Member(_canvasLabel));
        }

        [Test]
        public void TestRenderPlotsShouldNotReturnLabelIfLabelIsNull()
        {
            _plot.Label = null;
            var results = _renderer.RenderPlots(_controlSize, _viewExtent, _plots);
            Assert.That(results, !Has.Member(_canvasLabel));
        }

        [Test]
        public void TestRenderPlotsShouldNotReturnLabelIfLabelIsEmpty()
        {
            _plot.Label = string.Empty;
            var results = _renderer.RenderPlots(_controlSize, _viewExtent, _plots);
            Assert.That(results, !Has.Member(_canvasLabel));
        }
    }
}
