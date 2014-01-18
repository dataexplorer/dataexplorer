using System;
using DataExplorer.Domain.Filters;
using DataExplorer.Presentation.Panes.Filter.BooleanFilters;
using NUnit.Framework;

namespace DataExplorer.Presentation.Tests.Panes.Filter.BooleanFilters
{
    [TestFixture]
    public class BooleanFilterViewModelTests
    {
        private BooleanFilterViewModel _viewModel;
        private BooleanFilter _filter;

        [SetUp]
        public void SetUp()
        {
            _filter = new BooleanFilter(null, false, false, false);

            _viewModel = new BooleanFilterViewModel(_filter);
        }

        [Test]
        public void TestGetSetIncludeTrueShouldGetSetIncludeTrueFromFilter()
        {
            _viewModel.IncludeTrue = true;
            var result = _viewModel.IncludeTrue;
            Assert.That(result, Is.EqualTo(_filter.IncludeTrue));
        }

        [Test]
        public void TestGetIncludeFalseShouldReturnIncludeFalseFromFilter()
        {
            _viewModel.IncludeFalse = true;
            var result = _viewModel.IncludeFalse;
            Assert.That(result, Is.EqualTo(_filter.IncludeFalse));
        }
    }
}
