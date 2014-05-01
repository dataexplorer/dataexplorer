using System;
using System.Collections.Generic;
using System.Linq;
using DataExplorer.Application.Columns;
using DataExplorer.Application.Columns.Queries;
using DataExplorer.Application.Core.Messages;
using DataExplorer.Application.Layouts.Color.Commands;
using DataExplorer.Application.Layouts.Color.Queries;
using DataExplorer.Application.Layouts.General.Events;
using DataExplorer.Domain.Colors;
using DataExplorer.Domain.Layouts;
using DataExplorer.Presentation.Core.Layout;
using DataExplorer.Presentation.Panes.Layout.Color;
using DataExplorer.Presentation.Tests.Core;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Presentation.Tests.Panes.Layout.Color
{
    [TestFixture]
    public class ColorLayoutViewModelTests : ViewModelTests
    {
        private ColorLayoutViewModel _viewModel;
        private Mock<IMessageBus> _mockMessageBus;
        private ColumnDto _columnDto;
        private ColorPalette _colorPalette;

        [SetUp]
        public void SetUp()
        {
            _columnDto = new ColumnDto()
            {
                Id = 1,
                Name = "Test"
            };
            _colorPalette = new ColorPalette("Test", new List<Domain.Colors.Color>());

            _mockMessageBus = new Mock<IMessageBus>();
            _mockMessageBus.Setup(p => p.Execute(It.IsAny<GetAllColorColumnsQuery>()))
                .Returns(new List<ColumnDto> { _columnDto });
            _mockMessageBus.Setup(p => p.Execute(It.IsAny<GetColorColumnQuery>()))
                .Returns(_columnDto);

            _viewModel = new ColorLayoutViewModel(
                _mockMessageBus.Object);
        }

        [Test]
        public void TestLabelShouldReturnLabel()
        {
            Assert.That(_viewModel.Label, Is.EqualTo("Color"));
        }

        [Test]
        public void TestGetColumnsShouldReturnEmptyColumn()
        {
            var result = _viewModel.Columns;
            Assert.That(result.First().Name, Is.Empty);
        }

        [Test]
        public void TestColumnsShouldReturnColumns()
        {
            var result = _viewModel.Columns;

            Assert.That(result.Last().Column, Is.EqualTo(_columnDto));
        }

        [Test]
        public void TestGetSelectedColumnShouldReturnSelectedColumn()
        {
            var result = _viewModel.SelectedColumn;
            
            Assert.That(result.Column, Is.EqualTo(_columnDto));
        }

        [Test]
        public void TestSetSelectedColumnToNullShouldDoNothing()
        {
            _viewModel.SelectedColumn = null;
            _mockMessageBus.Verify(p => p.Execute(It.IsAny<UnsetColorColumnCommand>()), Times.Never());
            _mockMessageBus.Verify(p => p.Execute(It.IsAny<SetColorColumnCommand>()), Times.Never());
        }

        [Test]
        public void TestSetSelectedColumnToNoColumnShouldUnsetSelectedColumn()
        {
            _viewModel.SelectedColumn = new LayoutItemViewModel(null);
            _mockMessageBus.Verify(p => p.Execute(It.IsAny<UnsetColorColumnCommand>()), Times.Once());
        }

        [Test]
        public void TestSetSelectedColumnShouldSetSelectedColumn()
        {
            var columnViewModel = new LayoutItemViewModel(_columnDto);
            
            _viewModel.SelectedColumn = columnViewModel;
            
            _mockMessageBus.Verify(p => p.Execute(
                It.Is<SetColorColumnCommand>(q => q.Id == _columnDto.Id)), 
                Times.Once());
        }

        [Test]
        public void TestGetSortCommandTextShouldReturnOppositeSortOrder()
        {
            var result = _viewModel.SortCommandText;
            Assert.That(result, Is.EqualTo("Sort Descending"));
        }

        [Test]
        public void TestExecuteSortCommandShouldToggleSortOrder()
        {
            _viewModel.SortCommand.Execute(null);
            _mockMessageBus.Verify(p => p.Execute(
                It.Is<SetColorSortOrderCommand>(q => q.SortOrder == SortOrder.Descending)),
                Times.Once());
        }

        [Test]
        public void TestGetColorPalettesReturnsColorPalettes()
        {
            _mockMessageBus.Setup(p => p.Execute(It.IsAny<GetAllColorPalettesQuery>()))
                .Returns(new List<ColorPalette> { _colorPalette });

            var results = _viewModel.ColorPalettes;

            Assert.That(results.Single().ColorPalette, Is.EqualTo(_colorPalette));
        }

        [Test]
        public void TestGetSelectedColorPaletteShouldReturnSelectedColorPalette()
        {
            _mockMessageBus.Setup(p => p.Execute(It.IsAny<GetColorPaletteQuery>()))
                .Returns(_colorPalette);

            var result = _viewModel.SelectedColorPalette;

            Assert.That(result.ColorPalette, Is.EqualTo(_colorPalette));
        }

        [Test]
        public void TestSetSelectedColorPaletteShouldSetSelectedColorPalette()
        {
            _viewModel.SelectedColorPalette = new ColorPaletteViewModel(_colorPalette);

            _mockMessageBus.Verify(p => p.Execute(
                It.Is<SetColorPaletteCommand>(q => q.Entity == _colorPalette)), 
                Times.Once());
        }

        [Test]
        public void TestHandleLayoutChangedEventShouldNotifyPropertyChanged()
        {
            AssertPropertyChanged(_viewModel, () => _viewModel.SelectedColumn,
                () => _viewModel.Handle(new LayoutChangedEvent()));

            AssertPropertyChanged(_viewModel, () => _viewModel.SortCommandText,
                () => _viewModel.Handle(new LayoutChangedEvent()));
        }

        [Test]
        public void TestHandleLayoutResetEventShouldNotifyPropertyChanged()
        {
            AssertPropertyChanged(_viewModel, () => _viewModel.Columns, 
                () => _viewModel.Handle(new LayoutResetEvent()));

            AssertPropertyChanged(_viewModel, () => _viewModel.SelectedColumn,
                () => _viewModel.Handle(new LayoutResetEvent()));

            AssertPropertyChanged(_viewModel, () => _viewModel.SortCommandText,
                () => _viewModel.Handle(new LayoutResetEvent()));

            AssertPropertyChanged(_viewModel, () => _viewModel.SelectedColorPalette,
                () => _viewModel.Handle(new LayoutChangedEvent()));
        }
    }
}
