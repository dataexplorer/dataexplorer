using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using DataExplorer.Application.Columns;
using DataExplorer.Application.Columns.Queries;
using DataExplorer.Application.Core.Messages;
using DataExplorer.Application.Views.ScatterPlots.Layouts.Commands;
using DataExplorer.Application.Views.ScatterPlots.Layouts.Events;
using DataExplorer.Application.Views.ScatterPlots.Layouts.Queries;
using DataExplorer.Presentation.Core.Layout;
using DataExplorer.Presentation.Tests.Core;
using DataExplorer.Presentation.Views.ScatterPlots.Layout.XAxis;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Presentation.Tests.Views.ScatterPlots.Layouts
{
    [TestFixture]
    public class XAxisLayoutViewModelTests : ViewModelTests
    {
        private XAxisLayoutViewModel _viewModel;
        private Mock<IMessageBus> _mockMessageBus;
        
        [SetUp]
        public void SetUp()
        {
            _mockMessageBus = new Mock<IMessageBus>();

            _viewModel = new XAxisLayoutViewModel(_mockMessageBus.Object);
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
            _mockMessageBus.Setup(p => p.Execute(It.IsAny<GetAllColumnsQuery>()))
                .Returns(columnDtos);
            var result = _viewModel.Columns;
            Assert.That(result.Single().Name, Is.EqualTo(columnDto.Name));
        }

        [Test]
        public void TestGetSelectedColumnhouldReturnSelectedColumn()
        {
            var columnDto = new ColumnDto() { Name = "Test" };
            _mockMessageBus.Setup(p => p.Execute(It.IsAny<GetXColumnQuery>()))
                .Returns(columnDto);
            var result = _viewModel.SelectedColumn;
            Assert.That(result.Name, Is.EqualTo(columnDto.Name));
        }

        [Test]
        public void TestSetSelectedColumnShouldReturnIfNull()
        {
            _viewModel.SelectedColumn = null;
            _mockMessageBus.Verify(p => p.Execute(It.IsAny<SetXColumnCommand>()), Times.Never());
        }

        [Test]
        public void TestSetSelectedColumnShouldSetSelectedColumn()
        {
            var columnDto = new ColumnDto() { Id = 1 };
            var viewModel = new LayoutItemViewModel(columnDto);
            _viewModel.SelectedColumn = viewModel;
            _mockMessageBus.Verify(p => p.Execute(It.Is<SetXColumnCommand>(q => q.Id == 1)), Times.Once());
        }

        [Test]
        public void TestHandleLayoutChangedEventShouldNotifyPropertyChanged()
        {
            AssertPropertyChanged(_viewModel, () => _viewModel.SelectedColumn,
                () => _viewModel.Handle(new LayoutChangedEvent()));
        }

        [Test]
        public void TestHandleLayoutResetEventShouldNotifyPropertyChanged()
        {
            AssertPropertyChanged(_viewModel, () => _viewModel.Columns,
                () => _viewModel.Handle(new LayoutResetEvent()));

            AssertPropertyChanged(_viewModel, () => _viewModel.SelectedColumn,
                () => _viewModel.Handle(new LayoutResetEvent()));
        }
    }
}
