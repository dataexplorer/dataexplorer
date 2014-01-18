using DataExplorer.Application.Core.Commands;
using DataExplorer.Application.Filters.Events;
using DataExplorer.Application.Importers.CsvFiles.Events;
using DataExplorer.Application.Projects.Events;
using DataExplorer.Application.Views.ScatterPlots;
using DataExplorer.Application.Views.ScatterPlots.Commands;
using DataExplorer.Domain.Views.ScatterPlots;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Application.Tests.Views.ScatterPlots
{
    [TestFixture]
    public class ScatterPlotEventsServiceTests
    {
        private ScatterPlotEventsService _service;
        private Mock<ICommandBus> _mockTask;

        [SetUp]
        public void SetUp()
        {
            _mockTask = new Mock<ICommandBus>();
            _service = new ScatterPlotEventsService(_mockTask.Object);
        }

        [Test]
        public void TestHandleProjectOpenedEventShouldUpdatePlots()
        {
            var @event = new ProjectOpenedEvent();
            _service.Handle(@event);
            _mockTask.Verify(p => p.Execute(It.IsAny<UpdatePlotsCommand>()),
                Times.Once());
        }

        [Test]
        public void TestHandleProjectClosedEventShouldUpdatePlots()
        {
            var @event = new ProjectClosedEvent();
            _service.Handle(@event);
            _mockTask.Verify(p => p.Execute(It.IsAny<UpdatePlotsCommand>()),
                Times.Once());
        }

        [Test]
        public void TestHandleScatterPlotLayoutChangedEventShouldUpdatePlots()
        {
            var @event = new ScatterPlotLayoutColumnChangedEvent();
            _service.Handle(@event);
            _mockTask.Verify(p => p.Execute(It.IsAny<UpdatePlotsCommand>()),
                Times.Once());
        }

        [Test]
        public void TestHandleDataImportedEventShouldUpdatePlots()
        {
            var @event = new CsvFileImportedEvent();
            _service.Handle(@event);
            _mockTask.Verify(p => p.Execute(It.IsAny<UpdatePlotsCommand>()),
                Times.Once());
        }

        [Test]
        public void TestHandleFilterAddedEventShouldUpdatePlots()
        {
            var @event = new FilterAddedEvent(null);
            _service.Handle(@event);
            _mockTask.Verify(p => p.Execute(It.IsAny<UpdatePlotsCommand>()),
                Times.Once());
        }

        [Test]
        public void TestHandleFilterRemovedEventShouldUpdatePlots()
        {
            var @event = new FilterRemovedEvent(null);
            _service.Handle(@event);
            _mockTask.Verify(p => p.Execute(It.IsAny<UpdatePlotsCommand>()),
                Times.Once());
        }

        [Test]
        public void TestHandleFilterChangedEventShouldUpdatePlots()
        {
            var @event = new FilterChangedEvent(null);
            _service.Handle(@event);
            _mockTask.Verify(p => p.Execute(It.IsAny<UpdatePlotsCommand>()),
                Times.Once());
        }
    }
}
