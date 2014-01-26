using DataExplorer.Application.Columns;
using DataExplorer.Application.Core.Events;
using DataExplorer.Application.Core.Messages;
using DataExplorer.Application.Importers.CsvFiles.Events;
using DataExplorer.Application.Projects.Events;
using DataExplorer.Application.Views.ScatterPlots;
using DataExplorer.Application.Views.ScatterPlots.Layouts.Events;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Application.Tests.Views.ScatterPlots
{
    [TestFixture]
    public class ScatterPlotLayoutServiceTests
    {
        private LayoutEventService _service;
        private Mock<IEventBus> _mockEventBus;
        
        [SetUp]
        public void SetUp()
        {
            _mockEventBus = new Mock<IEventBus>();
            _service = new LayoutEventService(_mockEventBus.Object);
        }
        
        [Test]
        public void TestHandleProjectOpenedShouldRaiseLayoutColumnsChangedEvent()
        {
            var args = new ProjectOpenedEvent();
            _service.Handle(args);
            _mockEventBus.Verify(p => p.Raise(It.IsAny<LayoutResetEvent>()));
        }

        [Test]
        public void TestHandleProjectClosedShouldRaiseLayoutColumnsChangedEvent()
        {
            var args = new ProjectClosedEvent();
            _service.Handle(args);
            _mockEventBus.Verify(p => p.Raise(It.IsAny<LayoutResetEvent>()));
        }

        [Test]
        public void TestHandleDataImportedEventShouldRaiseLayoutColumnsChangedEvent()
        {
            var args = new CsvFileImportedEvent();
            _service.Handle(args);
            _mockEventBus.Verify(p => p.Raise(It.IsAny<LayoutResetEvent>()));
        }
    }
}
