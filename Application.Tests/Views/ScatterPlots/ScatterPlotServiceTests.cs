using System.Collections.Generic;
using System.Linq;
using System.Windows;
using DataExplorer.Application.Views.ScatterPlots;
using DataExplorer.Application.Views.ScatterPlots.Commands;
using DataExplorer.Application.Views.ScatterPlots.Queries;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Application.Tests.Views.ScatterPlots
{
    [TestFixture]
    public class ScatterPlotServiceTests
    {
        private ScatterPlotService _service;
        private Mock<IGetViewExtentQuery> _mockGetViewExtentQuery;
        private Mock<ISetViewExtentCommand> _mockSetViewExtentCommand;
        private Mock<IGetPlotsQuery> _mockGetPlotsQuery;
        private Mock<IZoomInCommand> _mockZoomInCommand;
        private Mock<IZoomOutCommand> _mockZoomOutCommand;
        private Mock<IZoomToFullExtentCommand> _mockZoomExtentCommand;
        private Mock<IPanCommand> _mockPanTask;
        private Rect _viewExtent;
        private List<PlotDto> _plotDtos;
        private PlotDto _plotDto;

        [SetUp]
        public void SetUp()
        {
            _viewExtent = new Rect();
            _plotDto = new PlotDto();
            _plotDtos = new List<PlotDto> { _plotDto };
            _mockGetViewExtentQuery = new Mock<IGetViewExtentQuery>();
            _mockSetViewExtentCommand = new Mock<ISetViewExtentCommand>();
            _mockGetPlotsQuery = new Mock<IGetPlotsQuery>();
            _mockGetPlotsQuery.Setup(p => p.GetPlots()).Returns(_plotDtos);
            _mockZoomInCommand = new Mock<IZoomInCommand>();
            _mockZoomOutCommand = new Mock<IZoomOutCommand>();
            _mockZoomExtentCommand = new Mock<IZoomToFullExtentCommand>();
            _mockPanTask = new Mock<IPanCommand>();
            _service = new ScatterPlotService( 
                _mockGetViewExtentQuery.Object,
                _mockSetViewExtentCommand.Object,
                _mockGetPlotsQuery.Object,
                _mockZoomInCommand.Object,
                _mockZoomOutCommand.Object,
                _mockZoomExtentCommand.Object,
                _mockPanTask.Object);
        }

        [Test]
        public void TestGetViewExtentShouldGetViewExtent()
        {
            var result = _service.GetViewExtent();
            Assert.That(result, Is.EqualTo(_viewExtent));
        }

        [Test]
        public void TestSetViewExtentShouldSetViewExtent()
        {
            _service.SetViewExtent(_viewExtent);
            _mockSetViewExtentCommand.Verify(p => p.SetViewExtent(_viewExtent), Times.Once());
        }

        [Test]
        public void TestGetShouldReturnScatterPlotToDto()
        {
            var results = _service.GetPlots();
            Assert.That(results.Single(), Is.EqualTo(_plotDto));
        }

        [Test]
        public void TestZoomInShouldZoomIn()
        {
            var point = new Point();
            _service.ZoomIn(point);
            _mockZoomInCommand.Verify(p => p.ZoomIn(point), Times.Once());
        }

        [Test]
        public void TestZoomOutShouldZoomOut()
        {
            var point = new Point();
            _service.ZoomOut(point);
            _mockZoomOutCommand.Verify(p => p.ZoomOut(point), Times.Once());
        }

        [Test]
        public void TestZoomToFullExtentShouldZoomToFullExtent()
        {
            _service.ZoomToFullExtent();
            _mockZoomExtentCommand.Verify(p => p.Execute(), Times.Once());
        }

        [Test]
        public void TestPanShouldPan()
        {
            var vector = new Vector();
            _service.Pan(vector);
            _mockPanTask.Verify(p => p.Pan(vector));
        }
    }
}
