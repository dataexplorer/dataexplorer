using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DataExplorer.Application.ScatterPlots;
using DataExplorer.Presentation.Core.Canvas.Items;
using DataExplorer.Presentation.Core.Geometry;
using DataExplorer.Presentation.Views.ScatterPlots.Renderers;
using DataExplorer.Presentation.Views.ScatterPlots.Scalers;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Tests.Presentation.Views.ScatterPlots.Renderers
{
    [TestFixture]
    public class ScatterPlotPlotRendererTests
    {
        private ScatterPlotPlotRenderer _renderer;
        private Mock<IViewResizer> _mockResizer;
        private Mock<IScaleComputer> _mockComputer;
        private Mock<IGeometryCalculator> _mockCalculator;
        private Mock<IGeometryFactory> _mockFactory;
        private Size _controlSize;
        private Rect _viewExtent;
        private PlotDto _plot;
        private List<PlotDto> _plots;
        private CanvasCircle _circle;

        [SetUp]
        public void SetUp()
        {
            _controlSize = new Size();
            _viewExtent = new Rect();
            _plot = new PlotDto() { X = 1d, Y = 2d };
            _plots = new List<PlotDto> { _plot };
            _circle = new CanvasCircle();

            _mockResizer = new Mock<IViewResizer>();
            _mockResizer.Setup(p => p.ResizeView(_controlSize, _viewExtent)).Returns(_viewExtent);

            _mockComputer = new Mock<IScaleComputer>();
            _mockComputer.Setup(p => p.ComputeScale(_controlSize, _viewExtent)).Returns(1d);

            _mockCalculator = new Mock<IGeometryCalculator>();

            _mockFactory = new Mock<IGeometryFactory>();
            _mockFactory.Setup(p => p.CreateCircle(It.IsAny<Rect>())).Returns(_circle);

            _renderer = new ScatterPlotPlotRenderer(
                _mockResizer.Object,
                _mockComputer.Object,
                _mockCalculator.Object,
                _mockFactory.Object);
        }

        [Test]
        public void TestRenderPlotsShouldReturnCircle()
        {
            var results = _renderer.RenderPlots(_controlSize, _viewExtent, _plots);
            Assert.That(results.Count, Is.EqualTo(1));
        }
    }
}
