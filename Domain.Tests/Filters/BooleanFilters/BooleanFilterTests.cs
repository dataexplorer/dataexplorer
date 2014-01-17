using System.Collections.Generic;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Filters.BooleanFilters;
using DataExplorer.Domain.Tests.Columns;
using NUnit.Framework;

namespace DataExplorer.Domain.Tests.Filters.BooleanFilters
{
    [TestFixture]
    public class BooleanFilterTests
    {
        private Column _column;
        private BooleanFilter _filter;

        [SetUp]
        public void SetUp()
        {
            _column = new ColumnBuilder().Build();
        }

        [Test]
        public void TestIncludeTrue()
        {
            _filter = new BooleanFilter(_column, true, false, false);
            Assert.That(_filter.IncludeTrue, Is.True);
        }

        [Test]
        public void TestIncludeFalse()
        {
            _filter = new BooleanFilter(_column, false, true, false);
            Assert.That(_filter.IncludeFalse, Is.True);
        }

        [Test]
        public void TestCreatePredicateShouldReturnBooleanPredicate()
        {
            _filter = new BooleanFilter(_column, true, true, false);
            var result = _filter.CreatePredicate();
            Assert.That(result, Is.Not.Null);
        }
    }
}
