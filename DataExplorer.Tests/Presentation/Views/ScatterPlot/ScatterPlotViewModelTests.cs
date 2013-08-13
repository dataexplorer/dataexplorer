using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DataExplorer.Application.ScatterPlot;
using DataExplorer.Presentation.Core.Geometry;
using DataExplorer.Presentation.Views.ScatterPlot;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Tests.Presentation.Views.ScatterPlot
{
    [TestFixture]
    public class ScatterPlotViewModelTests
    {
        private ScatterPlotViewModel _viewModel;
        private Mock<IScatterPlotService> _mockService;
        private Mock<IScatterPlotViewRenderer> _mockRenderer;

        [SetUp]
        public void SetUp()
        {
            _mockService = new Mock<IScatterPlotService>();
            _mockRenderer = new Mock<IScatterPlotViewRenderer>();
            _viewModel = new ScatterPlotViewModel(_mockService.Object, _mockRenderer.Object);
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
            var dto = new PlotDto() { X = 1d, Y = 2d };
            var dtos = new List<PlotDto>() { dto };
            var circle = new Circle() { X = 1d, Y = 2d };
            var circles = new List<Circle> { circle };
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
            _mockService.Raise(p => p.ScatterPlotChanged += null, EventArgs.Empty);
            Assert.That(wasPropertyChangeEventRaised, Is.EqualTo(true));
        }
    }

    

   
}
