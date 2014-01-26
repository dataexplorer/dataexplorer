using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Filters;
using DataExplorer.Application.Filters.Queries;
using DataExplorer.Domain.Filters;
using DataExplorer.Domain.Tests.Filters;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Application.Tests.Filters.Queries
{
    [TestFixture]
    public class GetFiltersQueryHandlerTests
    {
        private GetFiltersQueryHandler _handler;
        private Mock<IFilterRepository> _mockRepository;
        private Filter _filter;

        [SetUp]
        public void SetUp()
        {
            _filter = new FakeFilter();

            _mockRepository = new Mock<IFilterRepository>();
            _mockRepository.Setup(p => p.GetAll())
                .Returns(new List<Filter> { _filter });

            _handler = new GetFiltersQueryHandler(
                _mockRepository.Object);
        }

        [Test]
        public void TestExecuteShouldReturnAllFilters()
        {
            var results = _handler.Execute(new GetFiltersQuery());

            Assert.That(results.Single(), Is.EqualTo(_filter));
        }
    }
}
