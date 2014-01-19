using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Core.Commands;
using DataExplorer.Domain.Filters;
using DataExplorer.Presentation.Panes.Filter.NullFilters;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Presentation.Tests.Panes.Filter.NullFilters
{
    [TestFixture]
    public class NullFilterViewModelTests
    {
        private NullFilterViewModel _viewModel;
        private Mock<ICommandBus> _mockCommandBus;
        private NullFilter _filter;

        [SetUp]
        public void SetUp()
        {
            _filter = new NullFilter(null);

            _mockCommandBus = new Mock<ICommandBus>();

            _viewModel = new NullFilterViewModel(
                _mockCommandBus.Object,
                _filter);
        }

        [Test]
        public void TestConstructionOfFilter()
        {
            var result = _viewModel.Filter;
            Assert.That(result, Is.EqualTo(_filter));
        }
    }
}
