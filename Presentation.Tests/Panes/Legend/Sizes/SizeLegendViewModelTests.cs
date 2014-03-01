using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DataExplorer.Application.Columns;
using DataExplorer.Application.Core.Queries;
using DataExplorer.Application.Importers.CsvFiles.Events;
using DataExplorer.Application.Layouts.General.Events;
using DataExplorer.Application.Layouts.Size.Queries;
using DataExplorer.Application.Legends.Sizes;
using DataExplorer.Application.Legends.Sizes.Queries;
using DataExplorer.Application.Projects.Events;
using DataExplorer.Presentation.Panes.Legend.Sizes;
using DataExplorer.Presentation.Tests.Core;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Presentation.Tests.Panes.Legend.Sizes
{
    [TestFixture]
    public class SizeLegendViewModelTests : ViewModelTests
    {
        private SizeLegendViewModel _viewModel;
        private Mock<IQueryBus> _mockQueryBus;
        private ColumnDto _columnDto;
        private SizeLegendItemDto _itemDto;

        [SetUp]
        public void SetUp()
        {
            _columnDto = new ColumnDto() { Name = "test"};
            _itemDto = new SizeLegendItemDto()
            {
                Size = 1,
                Label = "Size 1"
            };

            _mockQueryBus = new Mock<IQueryBus>();
            _mockQueryBus.Setup(p => p.Execute(It.IsAny<GetSizeColumnQuery>()))
                .Returns(_columnDto);
            _mockQueryBus.Setup(p => p.Execute(It.IsAny<GetSizeLegendItemsQuery>()))
                .Returns(new List<SizeLegendItemDto> { _itemDto });

            _viewModel = new SizeLegendViewModel(
                _mockQueryBus.Object);
        }

        [Test]
        public void TestTitleShouldReturnEmptyStringIfNoSizeColumnSelected()
        {
            _mockQueryBus.Setup(p => p.Execute(It.IsAny<GetSizeColumnQuery>()))
                .Returns((ColumnDto) null);
            var result = _viewModel.Title;
            Assert.That(result, Is.Empty);
        }

        [Test]
        public void TestTitleShouldReturnTitle()
        {
            var result = _viewModel.Title;
            Assert.That(result, Is.EqualTo(_columnDto.Name));
        }

        [Test]
        public void TestItemsShouldReturnItems()
        {
            var result = _viewModel.Items;
            Assert.That(result.Single().Size, Is.EqualTo(1));
            Assert.That(result.Single().Label, Is.EqualTo(_itemDto.Label));
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
