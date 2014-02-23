using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Columns;
using DataExplorer.Application.Columns.Queries;
using DataExplorer.Application.Core.Messages;
using DataExplorer.Application.Layouts.General.Events;
using DataExplorer.Application.Layouts.Size.Commands;
using DataExplorer.Application.Layouts.Size.Queries;
using DataExplorer.Presentation.Core.Layout;
using DataExplorer.Presentation.Panes.Layout.Size;
using DataExplorer.Presentation.Tests.Core;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Presentation.Tests.Panes.Layout.Size
{
    [TestFixture]
    public class SizeLayoutViewModelTests : ViewModelTests
    {
        private SizeLayoutViewModel _viewModel;
        private Mock<IMessageBus> _mockMessageBus;
        private ColumnDto _columnDto;
        
        [SetUp]
        public void SetUp()
        {
            _columnDto = new ColumnDto();

            _mockMessageBus = new Mock<IMessageBus>();
            _mockMessageBus.Setup(p => p.Execute(It.IsAny<GetAllColumnsQuery>()))
                .Returns(new List<ColumnDto> { _columnDto });
            _mockMessageBus.Setup(p => p.Execute(It.IsAny<GetSizeColumnQuery>()))
                .Returns(_columnDto);
            _mockMessageBus.Setup(p => p.Execute(It.IsAny<GetLowerSizeValueQuery>()))
                .Returns(0.1d);
            _mockMessageBus.Setup(p => p.Execute(It.IsAny<GetUpperSizeValueQuery>()))
                .Returns(0.9d);
            
            _viewModel = new SizeLayoutViewModel(
                _mockMessageBus.Object);
        }

        [Test]
        public void TestLabelShouldReturnLabel()
        {
            Assert.That(_viewModel.Label, Is.EqualTo("Size"));
        }

        [Test]
        public void TestColumnsShouldReturnColumns()
        {
            var result = _viewModel.Columns;

            Assert.That(result.Single().Column, Is.EqualTo(_columnDto));
        }

        [Test]
        public void TestGetSelectedColumnShouldReturnSelectedColumn()
        {
            var result = _viewModel.SelectedColumn;

            Assert.That(result.Column, Is.EqualTo(_columnDto));
        }

        [Test]
        public void TestSetSelectedColumnShouldSetSelectedColumn()
        {
            var columnViewModel = new LayoutItemViewModel(_columnDto);

            _viewModel.SelectedColumn = columnViewModel;

            _mockMessageBus.Verify(p => p.Execute(
                It.Is<SetSizeColumnCommand>(q => q.Id == _columnDto.Id)),
                Times.Once());
        }

        [Test]
        public void TestIsLowerSliderVisibleShouldReturnTrueIfColumnIsSelected()
        {
            var result = _viewModel.IsLowerSizeSliderVisible;

            Assert.That(result, Is.True);
        }

        [Test]
        public void TestIsLowerSliderVisibleShouldReturnFalseIfColumnIsNotSelected()
        {
            _mockMessageBus.Setup(p => p.Execute(It.IsAny<GetSizeColumnQuery>()))
                .Returns((ColumnDto) null);

            var result = _viewModel.IsLowerSizeSliderVisible;

            Assert.That(result, Is.False);
        }

        [Test]
        public void TestGetLowerSizeSliderValueReturnsLowerSizeValue()
        {
            var result = _viewModel.LowerSizeSliderValue;

            Assert.That(result, Is.EqualTo(0.1d));
        }

        [Test]
        public void TestSetLowerSizeSliderValueShouldSetLowerSizeValue()
        {
            _viewModel.LowerSizeSliderValue = 0.2;

            _mockMessageBus.Verify(p => p.Execute(It.Is<SetLowerSizeValueCommand>(q => q.Value == 0.2d)));
        }

        [Test]
        public void TestGetUpperSizeSliderValueReturnsUpperSizeValue()
        {
            var result = _viewModel.UpperSizeSliderValue;

            Assert.That(result, Is.EqualTo(0.9d));
        }

        [Test]
        public void TestSetUpperSizeSliderValueShouldSetUpperSizeValue()
        {
            _viewModel.UpperSizeSliderValue = 0.8;

            _mockMessageBus.Verify(p => p.Execute(It.Is<SetUpperSizeValueCommand>(q => q.Value == 0.8d)));
        }

        [Test]
        public void TestHandleLayoutChangedEventShouldNotifyPropertyChanged()
        {
            AssertPropertyChanged(_viewModel, () => _viewModel.SelectedColumn,
                () => _viewModel.Handle(new LayoutChangedEvent()));
            AssertPropertyChanged(_viewModel, () => _viewModel.IsLowerSizeSliderVisible,
                () => _viewModel.Handle(new LayoutChangedEvent()));
            AssertPropertyChanged(_viewModel, () => _viewModel.LowerSizeSliderValue,
                () => _viewModel.Handle(new LayoutChangedEvent()));
            AssertPropertyChanged(_viewModel, () => _viewModel.UpperSizeSliderValue,
                () => _viewModel.Handle(new LayoutChangedEvent()));
        }

        [Test]
        public void TestHandleLayoutResetEventShouldNotifyPropertyChanged()
        {
            AssertPropertyChanged(_viewModel, () => _viewModel.Columns,
                () => _viewModel.Handle(new LayoutResetEvent()));
            AssertPropertyChanged(_viewModel, () => _viewModel.SelectedColumn,
                () => _viewModel.Handle(new LayoutResetEvent()));
            AssertPropertyChanged(_viewModel, () => _viewModel.IsLowerSizeSliderVisible,
                () => _viewModel.Handle(new LayoutChangedEvent()));
            AssertPropertyChanged(_viewModel, () => _viewModel.LowerSizeSliderValue,
                () => _viewModel.Handle(new LayoutChangedEvent()));
            AssertPropertyChanged(_viewModel, () => _viewModel.UpperSizeSliderValue,
                () => _viewModel.Handle(new LayoutChangedEvent()));
        }

    }
}
