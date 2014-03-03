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
        private ColumnDto _columnDto;

        [SetUp]
        public void SetUp()
        {
            _columnDto = new ColumnDto()
            {
                Id = 1,
                Name = "Test"
            };

            _mockMessageBus = new Mock<IMessageBus>();
            _mockMessageBus.Setup(p => p.Execute(It.IsAny<GetAllColumnsQuery>()))
                .Returns(new List<ColumnDto> { _columnDto });
            _mockMessageBus.Setup(p => p.Execute(It.IsAny<GetYColumnQuery>()))
                .Returns(_columnDto);

            _viewModel = new YAxisLayoutViewModel(_mockMessageBus.Object);
        }

        [Test]
        public void TestGetLabelShouldReturnYAxis()
        {
            Assert.That(_viewModel.Label, Is.EqualTo("y-Axis"));
        }

        [Test]
        public void TestGetColumnsShouldReturnEmptyColumn()
        {
            var result = _viewModel.Columns;
            Assert.That(result.First().Name, Is.Empty);
        }

        [Test]
        public void TestGetColumnsShouldReturnColumns()
        {
            var result = _viewModel.Columns;
            Assert.That(result.Last().Name, Is.EqualTo(_columnDto.Name));
        }

        [Test]
        public void TestGetSelectedColumnhouldReturnSelectedColumn()
        {
            var result = _viewModel.SelectedColumn;
            Assert.That(result.Name, Is.EqualTo(_columnDto.Name));
        }

        [Test]
        public void TestSetSelectedColumnToNullShouldUnsetSelectedColumn()
        {
            _viewModel.SelectedColumn = new LayoutItemViewModel(null);
            _mockMessageBus.Verify(p => p.Execute(It.IsAny<UnsetYAxisColumnCommand>()), Times.Once());
        }

        [Test]
        public void TestSetSelectedColumnShouldSetSelectedColumn()
        {
            var viewModel = new LayoutItemViewModel(_columnDto);
            _viewModel.SelectedColumn = viewModel;
            _mockMessageBus.Verify(p => p.Execute(It.Is<SetYAxisColumnCommand>(q => q.Id == 1)), Times.Once());
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
