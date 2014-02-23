using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Columns;
using DataExplorer.Application.Core.Events;
using DataExplorer.Application.Core.Queries;
using DataExplorer.Application.Importers.CsvFiles.Events;
using DataExplorer.Application.Legends;
using DataExplorer.Application.Legends.Colors;
using DataExplorer.Application.Legends.Colors.Queries;
using DataExplorer.Application.Projects.Events;
using DataExplorer.Application.Views.ScatterPlots.Layouts.Events;
using DataExplorer.Application.Views.ScatterPlots.Layouts.Queries;
using DataExplorer.Domain.Colors;
using DataExplorer.Presentation.Panes.Legend.Colors;
using DataExplorer.Presentation.Tests.Core;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Presentation.Tests.Panes.Legend.Colors
{
    [TestFixture]
    public class ColorLegendViewModelTests : ViewModelTests
    {
        private ColorLegendViewModel _viewModel;
        private Mock<IQueryBus> _mockQueryBus;
        private ColumnDto _column;
        private ColorLegendItemDto _colorLegendItemDto;

        [SetUp]
        public void SetUp()
        {
            _column = new ColumnDto() {Name = "test"};
            _colorLegendItemDto = new ColorLegendItemDto()
            {
                Color = new Color(0, 0, 0),
                Label = "Color 1"
            };

            _mockQueryBus = new Mock<IQueryBus>();
            _mockQueryBus.Setup(p => p.Execute(It.IsAny<GetColorColumnQuery>()))
                .Returns(_column);
            _mockQueryBus.Setup(p => p.Execute(It.IsAny<GetColorLegendItemsQuery>()))
                .Returns(new List<ColorLegendItemDto> {_colorLegendItemDto});

            _viewModel = new ColorLegendViewModel(_mockQueryBus.Object);
        }

        [Test]
        public void TestTitleShouldReturnEmptyStringIfNoColorColumnSelected()
        {
            _mockQueryBus.Setup(p => p.Execute(It.IsAny<GetColorColumnQuery>()))
                .Returns((ColumnDto) null);
            var result = _viewModel.Title;
            Assert.That(result, Is.Empty);
        }

        [Test]
        public void TestTitleShouldReturnTitle()
        {
            var result = _viewModel.Title;
            Assert.That(result, Is.EqualTo(_column.Name));
        }

        [Test]
        public void TestItemsShouldReturnItems()
        {
            var result = _viewModel.Items;
            Assert.That(result.Single().Color.R, Is.EqualTo(_colorLegendItemDto.Color.Red));
            Assert.That(result.Single().Color.G, Is.EqualTo(_colorLegendItemDto.Color.Green));
            Assert.That(result.Single().Color.B, Is.EqualTo(_colorLegendItemDto.Color.Blue));
            Assert.That(result.Single().Label, Is.EqualTo(_colorLegendItemDto.Label));
        }

        [Test]
        public void TestProjectOpenedEventShouldRaisePropertyChanged()
        {
            AssertPropertyChangedEventsRaised(() => _viewModel.Handle(new ProjectOpenedEvent()));
        }

        [Test]
        public void TestProjectClosedEventShouldRaisePropertyChanged()
        {
            AssertPropertyChangedEventsRaised(() => _viewModel.Handle(new ProjectClosedEvent()));
        }

        [Test]
        public void TestSourceImportedEventShouldRaisePropertyChanged()
        {
            AssertPropertyChangedEventsRaised(() => _viewModel.Handle(new SourceImportedEvent()));
        }

        [Test]
        public void TestLayoutChangedEventShouldRaisePropertyChanged()
        {
            AssertPropertyChangedEventsRaised(() => _viewModel.Handle(new LayoutChangedEvent()));
        }

        private void AssertPropertyChangedEventsRaised(Action handlEventAction)
        {
            AssertPropertyChanged(_viewModel, () => _viewModel.Title, handlEventAction);
            AssertPropertyChanged(_viewModel, () => _viewModel.Items, handlEventAction);
        }
    }
}
