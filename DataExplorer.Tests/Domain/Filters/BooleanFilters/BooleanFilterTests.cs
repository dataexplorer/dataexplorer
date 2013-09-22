using System.Collections.Generic;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Filters.BooleanFilters;
using DataExplorer.Tests.Domain.Columns;
using NUnit.Framework;

namespace DataExplorer.Tests.Domain.Filters.BooleanFilters
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
        public void TestDefaultConstructorShouldSetValues()
        {
            var values = new List<bool?> { true };
            _filter = new BooleanFilter(_column, values);
            Assert.That(_filter.Values, Has.Member(true));
        }

        [Test]
        public void TestValueShouldReturnFalseIfNullIsIncluded()
        {
            var filter = new BooleanFilter(_column, (bool?) null);
            Assert.That(filter.Values.Contains(null));
        }

        [Test]
        public void TestValueShouldReturnFalseIfFalseIsIncluded()
        {
            _filter = new BooleanFilter(_column, false);
            Assert.That(_filter.Values.Contains(false));
        }

        [Test]
        public void TestValueShouldReturnTrueIfTrueIsIncluded()
        {
            _filter = new BooleanFilter(_column, true);
            Assert.That(_filter.Values.Contains(true));
        }

        [Test]
        public void TestCreatePredicateShouldReturnBooleanPredicate()
        {
            _filter = new BooleanFilter(_column, false);
            var result = _filter.CreatePredicate();
            Assert.That(result != null);
        }
    }
}
