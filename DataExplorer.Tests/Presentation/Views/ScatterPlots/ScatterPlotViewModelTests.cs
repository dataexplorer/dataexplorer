using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DataExplorer.Application.ScatterPlots;
using DataExplorer.Domain.ScatterPlots;
using DataExplorer.Presentation.Core.Geometry;
using DataExplorer.Presentation.Views.ScatterPlots;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Tests.Presentation.Views.ScatterPlots
{
    [TestFixture]
    public class ScatterPlotViewModelTests
    {
        private ScatterPlotViewModel _viewModel;
        private Mock<IScatterPlotService> _mockService;
        private Mock<IScatterPlotViewRenderer> _mockRenderer;
        private Mock<IScatterPlotViewScaler> _mockScaler;

        [SetUp]
        public void SetUp()
        {
            _mockService = new Mock<IScatterPlotService>();
            _mockRenderer = new Mock<IScatterPlotViewRenderer>();
            _mockScaler = new Mock<IScatterPlotViewScaler>();
            _viewModel = new ScatterPlotViewModel(
                _mockService.Object, 
                _mockRenderer.Object,
                _mockScaler.Object);
        }

        [Test]
        public void TestSetControlSizeShouldResizeViewExtent()
        {
            var controlSize = new Size();
            var viewExtent = new Rect();
            var newViewExtent = new Rect();
            _mockService.Setup(p => p.GetViewExtent()).Returns(viewExtent);
            _mockRenderer.Setup(p => p.ResizeView(controlSize, viewExtent)).Returns(newViewExtent);
            _viewModel.ControlSize = controlSize;
            _mockService.Verify(p => p.SetViewExtent(newViewExtent), Times.Once());
        }

        [Test]
        public void TestGetPlotsShouldReturnPlotGeometry()
        {
            var controlSize = new Size(0, 0);
            var viewExtent = new Rect(-100, -100, 1200, 1200);
            var dto = new PlotDto() {X = 1d, Y = 2d};
            var dtos = new List<PlotDto>() {dto};
            var circle = new Circle() {X = 1d, Y = 2d};
            var circles = new List<Circle> {circle};
            _mockService.Setup(p => p.GetViewExtent()).Returns(viewExtent);
            _mockService.Setup(p => p.GetPlots()).Returns(dtos);
            _mockRenderer.Setup(p => p.RenderPlots(controlSize, viewExtent, dtos)).Returns(circles);
            var results = _viewModel.Plots;
            Assert.That(results.Single().X, Is.EqualTo(1d));
            Assert.That(results.Single().Y, Is.EqualTo(2d));
        }

        [Test]
        public void TestHandleScatterPlotChangedEventShouldRaisePlotPropertyChangedEvent()
        {
            var wasPropertyChangeEventRaised = false;
            _viewModel.PropertyChanged += (s, e) => { wasPropertyChangeEventRaised = true; };
            _viewModel.Handle(new ScatterPlotChangedEvent());
            Assert.That(wasPropertyChangeEventRaised, Is.EqualTo(true));
        }

        [Test]
        public void TestZoomInShouldScaleZoomInValues()
        {
            var controlSize = new Size(100, 100);
            var viewExtent = new Rect(0, 0, 1, 1);
            var point = new Point(25, 50);
            var scaledPoint = new Point(0.25, -0.50);
            _viewModel.ControlSize = controlSize;
            _mockService.Setup(p => p.GetViewExtent()).Returns(viewExtent);
            _mockScaler.Setup(p => p.ScalePoint(point, controlSize, viewExtent)).Returns(scaledPoint);
            _viewModel.HandleZoomIn(point);
            _mockService.Verify(p => p.ZoomIn(scaledPoint));                  
        }

        [Test]
        public void TestZoomOutShouldScaleZoomOutValues()
        {
            var controlSize = new Size(100, 100);
            var viewExtent = new Rect(0, 0, 1, 1);
            var point = new Point(25, 50);
            var scaledPoint = new Point(0.25, -0.50);
            _viewModel.ControlSize = controlSize;
            _mockService.Setup(p => p.GetViewExtent()).Returns(viewExtent);
            _mockScaler.Setup(p => p.ScalePoint(point, controlSize, viewExtent)).Returns(scaledPoint);
            _viewModel.HandleZoomOut(point);
            _mockService.Verify(p => p.ZoomOut(scaledPoint));   
        }

        [Test]
        public void TestPanShouldScalePanValues()
        {
            var controlSize = new Size(100, 100);
            var viewExtent = new Rect(0, 0, 1, 1);
            var vector = new Vector(25, 50);
            var scaledVector = new Vector(0.25, -0.50);
            _viewModel.ControlSize = controlSize;
            _mockService.Setup(p => p.GetViewExtent()).Returns(viewExtent);
            _mockScaler.Setup(p => p.ScaleVector(vector, controlSize, viewExtent)).Returns(scaledVector);
            _viewModel.HandlePan(vector);
            _mockService.Verify(p => p.Pan(scaledVector));
        }
    }
}
