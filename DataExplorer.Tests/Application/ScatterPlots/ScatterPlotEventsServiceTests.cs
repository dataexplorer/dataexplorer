using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DataExplorer.Application.Filters;
using DataExplorer.Application.Importers;
using DataExplorer.Application.Importers.CsvFile;
using DataExplorer.Application.Importers.CsvFile.Events;
using DataExplorer.Application.ScatterPlots;
using DataExplorer.Application.ScatterPlots.Commands;
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
        private Mock<IUpdatePlotsCommand> _mockTask;

        [SetUp]
        public void SetUp()
        {
            _mockTask = new Mock<IUpdatePlotsCommand>();
            _service = new ScatterPlotEventsService(_mockTask.Object);
        }

        [Test]
        public void TestHandleProjectOpenedEventShouldUpdatePlots()
        {
            var @event = new ProjectOpenedEvent();
            _service.Handle(@event);
            _mockTask.Verify(p => p.UpdatePlots(), Times.Once());
        }

        [Test]
        public void TestHandleProjectClosedEventShouldUpdatePlots()
        {
            var @event = new ProjectClosedEvent();
            _service.Handle(@event);
            _mockTask.Verify(p => p.UpdatePlots(), Times.Once());
        }

        [Test]
        public void TestHandleScatterPlotLayoutChangedEventShouldUpdatePlots()
        {
            var @event = new ScatterPlotLayoutChangedEvent();
            _service.Handle(@event);
            _mockTask.Verify(p => p.UpdatePlots(), Times.Once());
        }

        [Test]
        public void TestHandleDataImportedEventShouldUpdatePlots()
        {
            var @event = new CsvFileImportedEvent();
            _service.Handle(@event);
            _mockTask.Verify(p => p.UpdatePlots(), Times.Once());
        }

        [Test]
        public void TestHandleFilterChangedEventShouldUpdatePlots()
        {
            var @event = new FilterChangedEvent();
            _service.Handle(@event);
            _mockTask.Verify(p => p.UpdatePlots(), Times.Once());
        }
    }
}
