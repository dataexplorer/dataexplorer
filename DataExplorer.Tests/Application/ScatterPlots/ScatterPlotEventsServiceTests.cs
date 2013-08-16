using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.ScatterPlots;
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
    public class ScatterPlotEventsServiceTests
    {
        private ScatterPlotEventsService _service;
        private Mock<IRowRepository> _mockDataRepository;
        private Mock<IViewRepository> _mockViewRepository;
        private Mock<IScatterPlotRenderer> _mockRenderer;
        private Mock<IScatterPlot> _mockScatterPlot;
        
        [SetUp]
        public void SetUp()
        {
            _mockDataRepository = new Mock<IRowRepository>();
            _mockViewRepository = new Mock<IViewRepository>();
            _mockRenderer = new Mock<IScatterPlotRenderer>();
            _mockScatterPlot = new Mock<IScatterPlot>();
            _service = new ScatterPlotEventsService(
                _mockDataRepository.Object,
                _mockViewRepository.Object,
                _mockRenderer.Object);
        }

        [Test]
        public void TestHandleProjectOpenedEventShouldUpdatePlots()
        {
            var @event = new ProjectOpenedEvent();
            var rows = new List<Row>();
            var plots = new List<Plot>();
            var layout = new ScatterPlotLayout();
            _mockDataRepository.Setup(p => p.GetAll()).Returns(rows);
            _mockViewRepository.Setup(p => p.GetScatterPlot()).Returns(_mockScatterPlot.Object);
            _mockScatterPlot.Setup(p => p.GetLayout()).Returns(layout);
            _mockRenderer.Setup(p => p.RenderPlots(rows, layout)).Returns(plots);
            _service.Handle(@event);
            _mockScatterPlot.Verify(p => p.SetPlots(plots), Times.Once());
        }

        [Test]
        public void TestHandleProjectClosedEventShouldUpdatePlots()
        {
            var @event = new ProjectClosedEvent();
            var rows = new List<Row>();
            var plots = new List<Plot>();
            var layout = new ScatterPlotLayout();
            _mockDataRepository.Setup(p => p.GetAll()).Returns(rows);
            _mockViewRepository.Setup(p => p.GetScatterPlot()).Returns(_mockScatterPlot.Object);
            _mockScatterPlot.Setup(p => p.GetLayout()).Returns(layout);
            _mockRenderer.Setup(p => p.RenderPlots(rows, layout)).Returns(plots);
            _service.Handle(@event);
            _mockScatterPlot.Verify(p => p.SetPlots(plots), Times.Once());
        }

        [Test]
        public void TestHandleScatterPlotLayoutChangedEventShouldUpdatePlots()
        {
            var @event = new ScatterPlotLayoutChangedEvent();
            var rows = new List<Row>();
            var plots = new List<Plot>();
            var layout = new ScatterPlotLayout();
            _mockDataRepository.Setup(p => p.GetAll()).Returns(rows);
            _mockViewRepository.Setup(p => p.GetScatterPlot()).Returns(_mockScatterPlot.Object);
            _mockScatterPlot.Setup(p => p.GetLayout()).Returns(layout);
            _mockRenderer.Setup(p => p.RenderPlots(rows, layout)).Returns(plots);
            _service.Handle(@event);
            _mockScatterPlot.Verify(p => p.SetPlots(plots), Times.Once());
        }
    }
}
