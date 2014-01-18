using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Tests.Columns;
using DataExplorer.Domain.Tests.Filters;
using DataExplorer.Presentation.Panes.Filter;
using NUnit.Framework;

namespace DataExplorer.Presentation.Tests.Panes.Filter
{
    [TestFixture]
    public class FilterViewModelTests
    {
        private FilterViewModel _viewModel;
        private Domain.Filters.Filter _filter;
        private Column _column;

        [SetUp]
        public void SetUp()
        {
            _column = new ColumnBuilder()
                .WithName("Test")
                .WithNulls()
                .Build();

            _filter = new FakeFilter(_column, false);

            _viewModel = new FakeViewModel(_filter);
        }

        [Test]
        public void TestGetLabelShouldReturnColumnName()
        {
            var result = _viewModel.Label;
            Assert.That(result, Is.EqualTo(_column.Name));
        }

        [Test]
        public void TestGetSetIncludeNull()
        {
            _viewModel.IncludeNull = true;
            var result = _viewModel.IncludeNull;
            Assert.That(result, Is.True);
        }

        [Test]
        public void TestGetIsIncludeNullVisibleShouldReturnTrueIfColumnHasNulls()
        {
            var result = _viewModel.IsIncludeNullVisible;
            Assert.That(result, Is.True);
        }
    }

    public class FakeViewModel : FilterViewModel
    {
        public FakeViewModel(Domain.Filters.Filter filter) : base(filter)
        {
        }
    }
}
