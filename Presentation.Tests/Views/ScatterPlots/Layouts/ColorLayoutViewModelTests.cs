using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Columns;
using DataExplorer.Application.Columns.Queries;
using DataExplorer.Application.Core.Messages;
using DataExplorer.Application.Views.ScatterPlots.Layouts.Commands;
using DataExplorer.Application.Views.ScatterPlots.Layouts.Events;
using DataExplorer.Application.Views.ScatterPlots.Layouts.Queries;
using DataExplorer.Domain;
using DataExplorer.Domain.Colors;
using DataExplorer.Presentation.Core.Layout;
using DataExplorer.Presentation.Tests.Core;
using DataExplorer.Presentation.Views.ScatterPlots.Layout.Color;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Presentation.Tests.Views.ScatterPlots.Layouts
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
            _columnDto = new ColumnDto();
            _colorPalette = new ColorPalette("Test", new List<Color>());

            _mockMessageBus = new Mock<IMessageBus>();
            
            _viewModel = new ColorLayoutViewModel(
                _mockMessageBus.Object);
        }

        [Test]
        public void TestLabelShouldReturnLabel()
        {
            Assert.That(_viewModel.Label, Is.EqualTo("Color"));
        }

        [Test]
        public void TestColumnsShouldReturnColumns()
        {
            _mockMessageBus.Setup(p => p.Execute(It.IsAny<GetAllColumnsQuery>()))
                .Returns(new List<ColumnDto> { _columnDto });

            var result = _viewModel.Columns;

            Assert.That(result.Single().Column, Is.EqualTo(_columnDto));
        }

        [Test]
        public void TestGetSelectedColumnShouldReturnSelectedColumn()
        {
            _mockMessageBus.Setup(p => p.Execute(It.IsAny<GetColorColumnQuery>()))
               .Returns(_columnDto);

            var result = _viewModel.SelectedColumn;
            
            Assert.That(result.Column, Is.EqualTo(_columnDto));
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
        }

        [Test]
        public void TestHandleLayoutResetEventShouldNotifyPropertyChanged()
        {
            AssertPropertyChanged(_viewModel, () => _viewModel.Columns, 
                () => _viewModel.Handle(new LayoutResetEvent()));

            AssertPropertyChanged(_viewModel, () => _viewModel.SelectedColumn,
                () => _viewModel.Handle(new LayoutResetEvent()));

            AssertPropertyChanged(_viewModel, () => _viewModel.SelectedColorPalette,
                () => _viewModel.Handle(new LayoutChangedEvent()));
        }
    }
}
