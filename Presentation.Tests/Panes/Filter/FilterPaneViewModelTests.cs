using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Core.Queries;
using DataExplorer.Application.Filters.Events;
using DataExplorer.Application.Filters.Queries;
using DataExplorer.Application.Importers.CsvFiles.Events;
using DataExplorer.Application.Projects.Events;
using DataExplorer.Domain.Tests.Filters;
using DataExplorer.Presentation.Panes.Filter;
using DataExplorer.Presentation.Tests.Core;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Presentation.Tests.Panes.Filter
{
    [TestFixture]
    public class FilterPaneViewModelTests : ViewModelTests
    {
        private FilterPaneViewModel _viewModel;
        private Mock<IQueryBus> _mockQueryBus;
        private Mock<IFilterViewModelFactory> _mockFactory;
        private FakeFilter _filter;
        private FakeFilterViewModel _filterViewModel;

        [SetUp]
        public void SetUp()
        {
            _filter = new FakeFilter();
            _filterViewModel = new FakeFilterViewModel(_filter);

            _mockQueryBus = new Mock<IQueryBus>();
            _mockQueryBus.Setup(p => p.Execute(It.IsAny<GetFiltersQuery>()))
                .Returns(new List<Domain.Filters.Filter> {_filter});

            _mockFactory = new Mock<IFilterViewModelFactory>();
            _mockFactory.Setup(p => p.Create(_filter)).Returns(_filterViewModel);

            _viewModel = new FilterPaneViewModel(
                _mockQueryBus.Object,
                _mockFactory.Object);
        }

        [Test]
        public void TestHandleSelectedFilterRaisePropertyChanged()
        {
            AssertPropertyChanged(_viewModel, () => _viewModel.FilterViewModels,
                () => _viewModel.Handle(new FilterAddedEvent(_filter)));
        }

        [Test]
        public void TestHandleSelectedFilterRemovedEventShouldRaisePropertyChanged()
        {
            AssertPropertyChanged(_viewModel, () => _viewModel.FilterViewModels,
                () => _viewModel.Handle(new FilterRemovedEvent(_filter)));
        }
       
        [Test]
        public void TestHandleProjectOpenedShouldRaisePropertyChanged()
        {
            AssertPropertyChanged(_viewModel, () => _viewModel.FilterViewModels,
                () => _viewModel.Handle(new ProjectOpenedEvent()));
        }

        [Test]
        public void TestHandleProjectClosedShouldRaisePropertyChanged()
        {
            AssertPropertyChanged(_viewModel, () => _viewModel.FilterViewModels,
                () => _viewModel.Handle(new ProjectClosedEvent()));
        }

        [Test]
        public void TestHandleSourceImportedShouldRaisePropertyChanged()
        {
            AssertPropertyChanged(_viewModel, () => _viewModel.FilterViewModels,
                () => _viewModel.Handle(new SourceImportedEvent()));
        }
    }

    internal class FakeFilterViewModel : FilterViewModel
    {
        public FakeFilterViewModel(Domain.Filters.Filter filter) : base(null, filter)
        {
        }
    }
}
