using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using DataExplorer.Application.Columns;
using DataExplorer.Application.Columns.Queries;
using DataExplorer.Application.Core.Queries;
using DataExplorer.Application.Views.ScatterPlots;
using DataExplorer.Application.Views.ScatterPlots.Events;
using DataExplorer.Domain.Views.ScatterPlots;
using DataExplorer.Presentation.Core.Layout;
using DataExplorer.Presentation.Views.ScatterPlots.Layout;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Presentation.Tests.Views.ScatterPlots.Layouts
{
    [TestFixture]
    public class XAxisLayoutViewModelTests
    {
        private XAxisLayoutViewModel _viewModel;
        private Mock<IQueryBus> _mockQueryService;
        private Mock<IScatterPlotLayoutService> _mockLayoutService;

        [SetUp]
        public void SetUp()
        {
            _mockQueryService = new Mock<IQueryBus>();
            _mockLayoutService = new Mock<IScatterPlotLayoutService>();

            _viewModel = new XAxisLayoutViewModel(
                _mockQueryService.Object,
                _mockLayoutService.Object);
        }

        [Test]
        public void TestGetLabelShouldReturnXAxis()
        {
            Assert.That(_viewModel.Label, Is.EqualTo("x-Axis"));
        }

        [Test]
        public void TestGetColumnsShouldReturnColumns()
        {
            var columnDto = new ColumnDto() { Name = "Test" };
            var columnDtos = new List<ColumnDto> { columnDto };
            _mockQueryService.Setup(p => p.Execute(It.IsAny<GetAllColumnsQuery>()))
                .Returns(columnDtos);
            var result = _viewModel.Columns;
            Assert.That(result.Single().Name, Is.EqualTo(columnDto.Name));
        }

        [Test]
        public void TestGetSelectedColumnhouldReturnSelectedColumn()
        {
            var columnDto = new ColumnDto() { Name = "Test" };
            _mockLayoutService.Setup(p => p.GetXColumn()).Returns(columnDto);
            var result = _viewModel.SelectedColumn;
            Assert.That(result.Name, Is.EqualTo(columnDto.Name));
        }

        [Test]
        public void TestSetSelectedColumnShouldReturnIfNull()
        {
            _viewModel.SelectedColumn = null;
            _mockLayoutService.Verify(p => p.SetXColumn(It.IsAny<ColumnDto>()), Times.Never());
        }

        [Test]
        public void TestSetSelectedColumnShouldSetSelectedColumn()
        {
            var columnDto = new ColumnDto() { Name = "Test" };
            var viewModel = new LayoutItemViewModel(columnDto);
            _viewModel.SelectedColumn = viewModel;
            _mockLayoutService.Verify(p => p.SetXColumn(columnDto), Times.Once());
        }

        [Test]
        public void TestHandleLayoutChangedEventShouldRaiseProperyChangedEvents()
        {
            var eventArgs = new List<PropertyChangedEventArgs>();
            _viewModel.PropertyChanged += (s, e) => eventArgs.Add(e);
            _viewModel.Handle(new ScatterPlotLayoutChangedEvent());
            Assert.That(eventArgs.Any(p => p.PropertyName == "SelectedColumn"));
            Assert.That(eventArgs.Any(p => p.PropertyName == "Columns"));
        }

        [Test]
        public void TestHandleLayoutChangedEventShouldRaiseSelectedColumnPropertyChangedEvent()
        {
            var wasRaised = false;
            _viewModel.PropertyChanged += (s, e) => { wasRaised = true; };
            _viewModel.Handle(new ScatterPlotLayoutColumnChangedEvent());
            Assert.That(wasRaised, Is.True);
        }
    }
}
