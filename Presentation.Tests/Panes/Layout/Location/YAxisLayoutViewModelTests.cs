using System.Collections.Generic;
using System.Linq;
using DataExplorer.Application.Columns;
using DataExplorer.Application.Columns.Queries;
using DataExplorer.Application.Core.Messages;
using DataExplorer.Application.Layouts.General.Events;
using DataExplorer.Application.Layouts.Location.Commands;
using DataExplorer.Application.Layouts.Location.Queries;
using DataExplorer.Presentation.Core.Layout;
using DataExplorer.Presentation.Panes.Layout.Location;
using DataExplorer.Presentation.Tests.Core;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Presentation.Tests.Panes.Layout.Location
{
    [TestFixture]
    public class YAxisLayoutViewModelTests : ViewModelTests
    {
        private YAxisLayoutViewModel _viewModel;
        private Mock<IMessageBus> _mockMessageBus;

        [SetUp]
        public void SetUp()
        {
            _mockMessageBus = new Mock<IMessageBus>();

            _viewModel = new YAxisLayoutViewModel(_mockMessageBus.Object);
        }

        [Test]
        public void TestGetLabelShouldReturnXAxis()
        {
            Assert.That(_viewModel.Label, Is.EqualTo("y-Axis"));
        }

        [Test]
        public void TestGetColumnsShouldReturnColumns()
        {
            var columnDto = new ColumnDto() { Name = "Test" };
            var columnDtos = new List<ColumnDto> { columnDto };
            _mockMessageBus.Setup(p => p.Execute(It.IsAny<GetAllColumnsQuery>())).Returns(columnDtos);
            var result = _viewModel.Columns;
            Assert.That(result.Single().Name, Is.EqualTo(columnDto.Name));
        }

        [Test]
        public void TestGetSelectedColumnhouldReturnSelectedColumn()
        {
            var columnDto = new ColumnDto() { Name = "Test" };
            _mockMessageBus.Setup(p => p.Execute(It.IsAny<GetYColumnQuery>()))
                .Returns(columnDto);
            var result = _viewModel.SelectedColumn;
            Assert.That(result.Name, Is.EqualTo(columnDto.Name));
        }

        [Test]
        public void TestSetSelectedColumnShouldReturnIfNull()
        {
            _viewModel.SelectedColumn = null;
            _mockMessageBus.Verify(p => p.Execute(It.IsAny<SetYColumnCommand>()), Times.Never());
        }

        [Test]
        public void TestSetSelectedColumnShouldSetSelectedColumn()
        {
            var columnDto = new ColumnDto() { Id = 1 };
            var viewModel = new LayoutItemViewModel(columnDto);
            _viewModel.SelectedColumn = viewModel;
            _mockMessageBus.Verify(p => p.Execute(It.Is<SetYColumnCommand>(q => q.Id == columnDto.Id)),
                Times.Once());
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
