using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Core.Commands;
using DataExplorer.Application.Filters.Commands;
using DataExplorer.Domain.Filters;
using DataExplorer.Presentation.Panes.Filter.ImageFilters;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Presentation.Tests.Panes.Filter.ImageFilters
{
    [TestFixture]
    public class ImageFilterViewModelTests
    {
        private ImageFilterViewModel _viewModel;
        private Mock<ICommandBus> _mockCommandBus;
        private ImageFilter _filter;

        [SetUp]
        public void SetUp()
        {
            _filter = new ImageFilter(null, false, false);

            _mockCommandBus = new Mock<ICommandBus>();

            _viewModel = new ImageFilterViewModel(
                _mockCommandBus.Object,
                _filter);
        }

        [Test]
        public void TestGetSetIncludeNotNullShouldGetSetIncludeNotNullFromFilter()
        {
            _viewModel.IncludeNotNull = true;
            var result = _viewModel.IncludeNotNull;
            Assert.That(result, Is.EqualTo(_filter.IncludeNotNull));
        }

        [Test]
        public void TestSetIncludeTrueShouldExecuteUpdateFilterCommand()
        {
            _viewModel.IncludeNotNull = true;
            _mockCommandBus.Verify(p => p.Execute(
                It.Is<UpdateFilterCommand>(q => q.Filter == _filter)),
                Times.Once());
        }
    }
}
