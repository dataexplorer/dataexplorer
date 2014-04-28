using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Columns;
using DataExplorer.Application.Columns.Queries;
using DataExplorer.Application.Core.Messages;
using DataExplorer.Application.Layouts.General.Events;
using DataExplorer.Application.Layouts.Label.Commands;
using DataExplorer.Application.Layouts.Label.Queries;
using DataExplorer.Presentation.Core.Layout;
using DataExplorer.Presentation.Panes.Layout.Label;
using DataExplorer.Presentation.Tests.Core;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Presentation.Tests.Panes.Layout.Label
{
    [TestFixture]
    public class LabelLayoutViewModelTests : ViewModelTests
    {
        private LabelLayoutViewModel _viewModel;
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
            _mockMessageBus.Setup(p => p.Execute(It.IsAny<GetAllLabelColumnsQuery>()))
                .Returns(new List<ColumnDto> { _columnDto });
            _mockMessageBus.Setup(p => p.Execute(It.IsAny<GetLabelColumnQuery>()))
                .Returns(_columnDto);

            _viewModel = new LabelLayoutViewModel(_mockMessageBus.Object);
        }

        [Test]
        public void TestGetLabelShouldReturnLabel()
        {
            Assert.That(_viewModel.Label, Is.EqualTo("Label"));
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
        public void TestSetSelectedColumnToNullShouldDoNothing()
        {
            _viewModel.SelectedColumn = null;
            _mockMessageBus.Verify(p => p.Execute(It.IsAny<UnsetLabelColumnCommand>()), Times.Never());
            _mockMessageBus.Verify(p => p.Execute(It.IsAny<SetLabelColumnCommand>()), Times.Never());
        }

        [Test]
        public void TestSetSelectedColumnToNoColumnShouldUnsetSelectedColumn()
        {
            _viewModel.SelectedColumn = new LayoutItemViewModel(null);
            _mockMessageBus.Verify(p => p.Execute(It.IsAny<UnsetLabelColumnCommand>()), Times.Once());
        }

        [Test]
        public void TestSetSelectedColumnShouldSetSelectedColumn()
        {
            var viewModel = new LayoutItemViewModel(_columnDto);
            _viewModel.SelectedColumn = viewModel;
            _mockMessageBus.Verify(p => p.Execute(It.Is<SetLabelColumnCommand>(q => q.Id == 1)), Times.Once());
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
