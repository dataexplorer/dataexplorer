using System.Collections.Generic;
using System.Linq;
using DataExplorer.Application;
using DataExplorer.Domain.Filters;
using DataExplorer.Domain.Tests.Filters;
using DataExplorer.Persistence.Filters;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Persistence.Tests.Filters
{
    [TestFixture]
    public class FilterRepositoryTests
    {
        private FilterRepository _repository;
        private Mock<IDataContext> _mockContext;
        private List<Filter> _filters;
        private FakeFilter _filter;

        [SetUp]
        public void SetUp()
        {
            _filter = new FakeFilter();
            _filters = new List<Filter>();
            _mockContext = new Mock<IDataContext>();
            _mockContext.Setup(p => p.Filters).Returns(_filters);
            _repository = new FilterRepository(_mockContext.Object);
        }

        [Test]
        public void TestGetAllShouldReturnAllFilters()
        {
            _filters.Add(_filter);
            var results = _repository.GetAll();
            Assert.That(results.Single(), Is.EqualTo(_filter));
        }

        [Test]
        public void TestAddShouldAddFilter()
        {
            _repository.Add(_filter);
            Assert.That(_filters, Has.Member(_filter));
        }

        [Test]
        public void TestRemoveShouldRemoveFilter()
        {
            _filters.Add(_filter);
            _repository.Remove(_filter);
            Assert.That(_filters, Has.No.Member(_filter));
        }
    }
}
