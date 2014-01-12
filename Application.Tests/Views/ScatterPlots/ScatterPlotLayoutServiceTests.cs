using DataExplorer.Application.Columns;
using DataExplorer.Application.Core.Events;
using DataExplorer.Application.Importers.CsvFiles.Events;
using DataExplorer.Application.Projects.Events;
using DataExplorer.Application.Views.ScatterPlots;
using DataExplorer.Application.Views.ScatterPlots.Events;
using DataExplorer.Application.Views.ScatterPlots.Layouts.Commands;
using DataExplorer.Application.Views.ScatterPlots.Layouts.Queries;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Application.Tests.Views.ScatterPlots
{
    [TestFixture]
    public class ScatterPlotLayoutServiceTests
    {
        private ScatterPlotLayoutService _service;
        private Mock<IGetXColumnQuery> _mockGetXColumnQuery;
        private Mock<ISetXColumnCommand> _mockSetXColumnCommand;
        private Mock<IGetYColumnQuery> _mockGetYColumnQuery;
        private Mock<ISetYColumnCommand> _mockSetYColumnCommand;
        private Mock<IClearLayoutCommand> _mockClearLayoutCommand;
        private Mock<IEventBus> _mockEventBus;
        private ColumnDto _columnDto;

        [SetUp]
        public void SetUp()
        {
            _columnDto = new ColumnDto();
            _mockGetXColumnQuery = new Mock<IGetXColumnQuery>();
            _mockSetXColumnCommand = new Mock<ISetXColumnCommand>();
            _mockGetYColumnQuery = new Mock<IGetYColumnQuery>();
            _mockSetYColumnCommand = new Mock<ISetYColumnCommand>();
            _mockClearLayoutCommand = new Mock<IClearLayoutCommand>();
            _mockEventBus = new Mock<IEventBus>();
            _service = new ScatterPlotLayoutService(
                _mockGetXColumnQuery.Object,
                _mockSetXColumnCommand.Object,
                _mockGetYColumnQuery.Object,
                _mockSetYColumnCommand.Object,
                _mockClearLayoutCommand.Object,
                _mockEventBus.Object);
        }

        [Test]
        public void TestGetXColumnShouldReturnXColumn()
        {
            _mockGetXColumnQuery.Setup(p => p.Query()).Returns(_columnDto);
            var result = _service.GetXColumn();
            Assert.That(result, Is.EqualTo(_columnDto));
        }

        [Test]
        public void TestSetXColumnShouldSetXColumn()
        {
            _service.SetXColumn(_columnDto);
            _mockSetXColumnCommand.Verify(p => p.Execute(_columnDto), Times.Once());
        }

        [Test]
        public void TestGetYColumnShouldReturnYColumn()
        {
            var columnDto = new ColumnDto();
            _mockGetYColumnQuery.Setup(p => p.Query()).Returns(columnDto);
            var result = _service.GetYColumn();
            Assert.That(result, Is.EqualTo(columnDto));
        }

        [Test]
        public void TestSetYColumnShouldSetYColumn()
        {
            _service.SetYColumn(_columnDto);
            _mockSetYColumnCommand.Verify(p => p.Execute(_columnDto), Times.Once());

        }

        [Test]
        public void TestClearLayoutShouldClearLayout()
        {
            _service.ClearLayout();
            _mockClearLayoutCommand.Verify(p => p.Execute(), Times.Once());
        }

        [Test]
        public void TestHandleProjectOpenedShouldRaiseLayoutColumnsChangedEvent()
        {
            var args = new ProjectOpenedEvent();
            _service.Handle(args);
            _mockEventBus.Verify(p => p.Raise(It.IsAny<ScatterPlotLayoutChangedEvent>()));
        }

        [Test]
        public void TestHandleProjectClosedShouldRaiseLayoutColumnsChangedEvent()
        {
            var args = new ProjectClosedEvent();
            _service.Handle(args);
            _mockEventBus.Verify(p => p.Raise(It.IsAny<ScatterPlotLayoutChangedEvent>()));
        }

        [Test]
        public void TestHandleDataImportedEventShouldRaiseLayoutColumnsChangedEvent()
        {
            var args = new CsvFileImportedEvent();
            _service.Handle(args);
            _mockEventBus.Verify(p => p.Raise(It.IsAny<ScatterPlotLayoutChangedEvent>()));
        }
    }
}
