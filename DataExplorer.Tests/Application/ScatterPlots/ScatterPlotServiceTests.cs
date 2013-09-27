using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DataExplorer.Application.ScatterPlots;
using DataExplorer.Application.ScatterPlots.Tasks;
using DataExplorer.Domain.Events;
using DataExplorer.Domain.Projects;
using DataExplorer.Domain.Rows;
using DataExplorer.Domain.ScatterPlots;
using DataExplorer.Domain.Views;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Tests.Application.ScatterPlots
{
    [TestFixture]
    public class ScatterPlotServiceTests
    {
        private ScatterPlotService _service;
        private Mock<IGetViewExtentTask> _mockGetViewExtentTask;
        private Mock<ISetViewExtentTask> _mockSetViewExtentTask;
        private Mock<IGetPlotsTask> _mockGetPlotsTask;
        private Mock<IZoomInTask> _mockZoomInTask;
        private Mock<IZoomOutTask> _mockZoomOutTask;
        private Mock<IPanTask> _mockPanTask;
        private Rect _viewExtent;
        private List<PlotDto> _plotDtos;
        private PlotDto _plotDto;

        [SetUp]
        public void SetUp()
        {
            _viewExtent = new Rect();
            _plotDto = new PlotDto();
            _plotDtos = new List<PlotDto> { _plotDto };
            _mockGetViewExtentTask = new Mock<IGetViewExtentTask>();
            _mockSetViewExtentTask = new Mock<ISetViewExtentTask>();
            _mockGetPlotsTask = new Mock<IGetPlotsTask>();
            _mockGetPlotsTask.Setup(p => p.GetPlots()).Returns(_plotDtos);
            _mockZoomInTask = new Mock<IZoomInTask>();
            _mockZoomOutTask = new Mock<IZoomOutTask>();
            _mockPanTask = new Mock<IPanTask>();
            _service = new ScatterPlotService( 
                _mockGetViewExtentTask.Object,
                _mockSetViewExtentTask.Object,
                _mockGetPlotsTask.Object,
                _mockZoomInTask.Object,
                _mockZoomOutTask.Object,
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
            _mockSetViewExtentTask.Verify(p => p.SetViewExtent(_viewExtent), Times.Once());
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
            _mockZoomInTask.Verify(p => p.ZoomIn(point), Times.Once());
        }

        [Test]
        public void TestZoomOutShouldZoomOut()
        {
            var point = new Point();
            _service.ZoomOut(point);
            _mockZoomOutTask.Verify(p => p.ZoomOut(point), Times.Once());
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
