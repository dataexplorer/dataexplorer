using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DataExplorer.Application.Importers;
using DataExplorer.Application.Importers.CsvFile;
using DataExplorer.Application.Importers.CsvFile.Events;
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
        private ScatterPlot _scatterPlot;
        
        [SetUp]
        public void SetUp()
        {
            _mockDataRepository = new Mock<IRowRepository>();
            _mockViewRepository = new Mock<IViewRepository>();
            _mockRenderer = new Mock<IScatterPlotRenderer>();
            _scatterPlot = new ScatterPlot();
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
            _scatterPlot = new ScatterPlot(new Rect(), plots, layout);
            _mockDataRepository.Setup(p => p.GetAll()).Returns(rows);
            _mockViewRepository.Setup(p => p.Get<ScatterPlot>()).Returns(_scatterPlot);
            _mockRenderer.Setup(p => p.RenderPlots(rows, layout)).Returns(plots);
            _service.Handle(@event);
            Assert.That(_scatterPlot.GetPlots(), Is.EqualTo(plots));
        }

        [Test]
        public void TestHandleProjectClosedEventShouldUpdatePlots()
        {
            var @event = new ProjectClosedEvent();
            var rows = new List<Row>();
            var plots = new List<Plot>();
            var layout = new ScatterPlotLayout();
            _scatterPlot = new ScatterPlot(new Rect(), plots, layout);
            _mockDataRepository.Setup(p => p.GetAll()).Returns(rows);
            _mockViewRepository.Setup(p => p.Get<ScatterPlot>()).Returns(_scatterPlot);
            _mockRenderer.Setup(p => p.RenderPlots(rows, layout)).Returns(plots);
            _service.Handle(@event);
            Assert.That(_scatterPlot.GetPlots(), Is.EqualTo(plots));
        }

        [Test]
        public void TestHandleScatterPlotLayoutChangedEventShouldUpdatePlots()
        {
            var @event = new ScatterPlotLayoutChangedEvent();
            var rows = new List<Row>();
            var plots = new List<Plot>();
            var layout = new ScatterPlotLayout();
            _scatterPlot = new ScatterPlot(new Rect(), plots, layout);
            _mockDataRepository.Setup(p => p.GetAll()).Returns(rows);
            _mockViewRepository.Setup(p => p.Get<ScatterPlot>()).Returns(_scatterPlot);
            _mockRenderer.Setup(p => p.RenderPlots(rows, layout)).Returns(plots);
            _service.Handle(@event);
            Assert.That(_scatterPlot.GetPlots(), Is.EqualTo(plots));
        }

        [Test]
        public void TestHandleDataImportedEventShouldUpdatePlots()
        {
            var @event = new CsvFileImportedEvent();
            var rows = new List<Row>();
            var plots = new List<Plot>();
            var layout = new ScatterPlotLayout();
            _scatterPlot = new ScatterPlot(new Rect(), plots, layout);
            _mockDataRepository.Setup(p => p.GetAll()).Returns(rows);
            _mockViewRepository.Setup(p => p.Get<ScatterPlot>()).Returns(_scatterPlot);
            _mockRenderer.Setup(p => p.RenderPlots(rows, layout)).Returns(plots);
            _service.Handle(@event);
            Assert.That(_scatterPlot.GetPlots(), Is.EqualTo(plots));
        }
    }
}
