using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DataExplorer.Application.ScatterPlots;
using DataExplorer.Presentation.Core.Canvas.Items;
using DataExplorer.Presentation.Core.Geometry;
using DataExplorer.Presentation.Views.ScatterPlots;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Tests.Presentation.Views.ScatterPlots
{
    [TestFixture]
    public class ScatterPlotViewRendererTests
    {
        private ScatterPlotViewRenderer _renderer;
        private Mock<IGeometryCalculator> _mockCalculator;
        private Mock<IGeometryFactory> _mockFactory;

        [SetUp]
        public void SetUp()
        {
            _mockCalculator = new Mock<IGeometryCalculator>();
            _mockFactory = new Mock<IGeometryFactory>();
            _renderer = new ScatterPlotViewRenderer(
                _mockCalculator.Object,
                _mockFactory.Object);
        }

        [Test]
        public void TestRenderPlotsShouldCalculateExtent()
        {
            var controlSize = new Size(1, 1);
            var viewExtent = new Rect(0, 0, 1, 1);
            var plot = new PlotDto() { X = 1d, Y = 2d };
            var plots = new List<PlotDto> { plot };
            _renderer.RenderPlots(controlSize, viewExtent, plots);
            _mockCalculator.Verify(p => p.CalculateExtent(controlSize, viewExtent, 1d, new Point(plot.X, plot.Y)));
        }

        [Test]
        public void TestRenderPlotsShouldCreateCircle()
        {
            var controlSize = new Size();
            var viewExtent = new Rect();
            var plot = new PlotDto() { X = 1d, Y = 2d };
            var plots = new List<PlotDto> { plot };
            var plotExtent = new Rect();
            _mockCalculator
                .Setup(p => p.CalculateExtent(
                    controlSize, 
                    viewExtent, 
                    0.0d, 
                    It.IsAny<Point>()))
                .Returns(plotExtent);
            _renderer.RenderPlots(controlSize, viewExtent, plots);
            _mockFactory.Verify(p => p.CreateCircle(plotExtent), Times.Once());
        }

        [Test]
        public void TestRenderPlotsShouldReturnCircle()
        {
            var controlSize = new Size();
            var viewExtent = new Rect();
            var plot = new PlotDto() { X = 1d, Y = 2d };
            var plots = new List<PlotDto> { plot };
            var circle = new CanvasCircle();
            _mockFactory.Setup(p => p.CreateCircle(It.IsAny<Rect>())).Returns(circle);
            var results = _renderer.RenderPlots(controlSize, viewExtent, plots);
            Assert.That(results.Count, Is.EqualTo(1));
        }

        [Test]
        public void TestComputeScaleShouldReturnActualWidthOverViewWidthIfActualWidthIsGreaterThanHeight()
        {
            var actualExtent = new Rect(0, 0, 1, 0);
            var viewExtent = new Rect(0, 0, 2, 0);
            var scale = _renderer.ComputeScale(actualExtent.Size, viewExtent);
            Assert.That(scale, Is.EqualTo(0.5));
        }

        [Test]
        public void TestComputeScaleShouldReturnActualHeightOverViewHeightIfActualHeightIsGreaterThanWidth()
        {
            var actualExtent = new Rect(0, 0, 0, 1);
            var viewExtent = new Rect(0, 0, 0, 4);
            var scale = _renderer.ComputeScale(actualExtent.Size, viewExtent);
            Assert.That(scale, Is.EqualTo(0.25));
        }

        [Test]
        public void TestResizeViewShouldHandleAllZeros()
        {
            var controlSize = new Size(0, 0);
            var viewExtent = new Rect(0, 0, 0, 0);
            var newExtent = new Rect(0, 0, 0, 0);
            var result = _renderer.ResizeView(controlSize, viewExtent);
            Assert.That(result, Is.EqualTo(newExtent));
        }

        [Test]
        public void TestResizeViewShouldScaleViewWidthWhenControlWidthIsReduced()
        {
            var controlSize = new Size(5, 10);
            var viewExtent = new Rect(0, 0, 10, 10);
            var newExtent = new Rect(0, -5, 10, 20);
            var result = _renderer.ResizeView(controlSize, viewExtent);
            Assert.That(result, Is.EqualTo(newExtent));
        }

        [Test]
        public void TestResizeViewShouldScaleViewHeightWhenControlHeightIsReduced()
        {
            var controlSize = new Size(10, 5);
            var viewExtent = new Rect(0, 0, 10, 10);
            var newExtent = new Rect(-5, 0, 20, 10);
            var result = _renderer.ResizeView(controlSize, viewExtent);
            Assert.That(result, Is.EqualTo(newExtent));
        }

        [Test]
        public void TestResizeViewShouldNotScaleViewWidthWhenControlWidthIsExpanded()
        {
            var controlSize = new Size(20, 10);
            var viewExtent = new Rect(0, 0, 10, 10);
            var newExtent = new Rect(-5, 0, 20, 10);
            var result = _renderer.ResizeView(controlSize, viewExtent);
            Assert.That(result, Is.EqualTo(newExtent));
        }

        [Test]
        public void TestResizeViewShouldNotScaleViewHeightWhenControlHeightIsExpanded()
        {
            var controlSize = new Size(10, 20);
            var viewExtent = new Rect(0, 0, 10, 10);
            var newExtent = new Rect(0, -5, 10, 20);
            var result = _renderer.ResizeView(controlSize, viewExtent);
            Assert.That(result, Is.EqualTo(newExtent));
        }

        
    }
}
