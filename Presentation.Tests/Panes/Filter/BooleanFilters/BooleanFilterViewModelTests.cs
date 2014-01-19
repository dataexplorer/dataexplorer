using System;
using DataExplorer.Application.Core.Commands;
using DataExplorer.Application.Filters.Commands;
using DataExplorer.Domain.Filters;
using DataExplorer.Presentation.Panes.Filter.BooleanFilters;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Presentation.Tests.Panes.Filter.BooleanFilters
{
    [TestFixture]
    public class BooleanFilterViewModelTests
    {
        private BooleanFilterViewModel _viewModel;
        private Mock<ICommandBus> _mockCommandBus;
        private BooleanFilter _filter;

        [SetUp]
        public void SetUp()
        {
            _filter = new BooleanFilter(null, false, false, false);

            _mockCommandBus = new Mock<ICommandBus>();

            _viewModel = new BooleanFilterViewModel(
                _filter, 
                _mockCommandBus.Object);
        }

        [Test]
        public void TestGetSetIncludeTrueShouldGetSetIncludeTrueFromFilter()
        {
            _viewModel.IncludeTrue = true;
            var result = _viewModel.IncludeTrue;
            Assert.That(result, Is.EqualTo(_filter.IncludeTrue));
        }

        [Test]
        public void TestSetIncludeTrueShouldExecuteUpdateFilterCommand()
        {
            _viewModel.IncludeTrue = true;
            _mockCommandBus.Verify(p => p.Execute(
                It.Is<UpdateFilterCommand>(q => q.Filter == _filter)),
                Times.Once());
        }

        [Test]
        public void TestGetIncludeFalseShouldReturnIncludeFalseFromFilter()
        {
            _viewModel.IncludeFalse = true;
            var result = _viewModel.IncludeFalse;
            Assert.That(result, Is.EqualTo(_filter.IncludeFalse));
        }

        [Test]
        public void TestSetIncludeFalseShouldExecuteUpdateFilterCommand()
        {
            _viewModel.IncludeFalse = true;
            _mockCommandBus.Verify(p => p.Execute(
                It.Is<UpdateFilterCommand>(q => q.Filter == _filter)), 
                Times.Once());
        }
    }
}
