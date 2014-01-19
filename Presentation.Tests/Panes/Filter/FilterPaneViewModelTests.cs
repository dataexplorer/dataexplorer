using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Filters.Events;
using DataExplorer.Domain.Tests.Filters;
using DataExplorer.Presentation.Panes.Filter;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Presentation.Tests.Panes.Filter
{
    [TestFixture]
    public class FilterPaneViewModelTests
    {
        private FilterPaneViewModel _viewModel;
        private Mock<IFilterViewModelFactory> _mockFactory;
        private FakeFilter _filter;
        private FakeFilterViewModel _filterViewModel;

        [SetUp]
        public void SetUp()
        {
            _filter = new FakeFilter();
            _filterViewModel = new FakeFilterViewModel(_filter);

            _mockFactory = new Mock<IFilterViewModelFactory>();
            _mockFactory.Setup(p => p.Create(_filter)).Returns(_filterViewModel);

            _viewModel = new FilterPaneViewModel(_mockFactory.Object);
        }

        [Test]
        public void TestConstructorShouldCreateEmptyListOfViewModels()
        {
            Assert.That(_viewModel.FilterViewModels.Count, Is.EqualTo(0));
        }

        [Test]
        public void TestHandleSelectedFilterAddedEventShouldAddFilterViewModel()
        {
            _viewModel.Handle(new FilterAddedEvent(_filter));
            Assert.That(_viewModel.FilterViewModels, Contains.Item(_filterViewModel));
        }

        [Test]
        public void TestHandleSelectedFilterRemovedEventShouldRemoveFilterViewModel()
        {
            _viewModel.FilterViewModels.Add(_filterViewModel);
            _viewModel.Handle(new FilterRemovedEvent(_filter));
            Assert.That(_viewModel.FilterViewModels.Contains(_filterViewModel), Is.False);
        }
    }

    internal class FakeFilterViewModel : FilterViewModel
    {
        public FakeFilterViewModel(Domain.Filters.Filter filter) : base(null, filter)
        {
        }
    }
}
