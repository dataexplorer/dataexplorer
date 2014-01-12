using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Filters.StringFilters;
using DataExplorer.Domain.Tests.Columns;
using NUnit.Framework;

namespace DataExplorer.Domain.Tests.Filters.StringFilters
{
    [TestFixture]
    public class NullableStringFilterTests
    {
        private NullableStringFilter _filter;
        private Column _column;

        [SetUp]
        public void SetUp()
        {
            _column = new ColumnBuilder().Build();
            _filter = new NullableStringFilter(_column, string.Empty, true);
        }

        [Test]
        public void TestGetIncludeNullsShouldReturnValue()
        {
            var result = _filter.IncludeNulls;
            Assert.That(result, Is.True);
        }

        [Test]
        public void TestCreatePredicateShouldReturnNullableBooleanPredicate()
        {
            var result = _filter.CreatePredicate();
            Assert.That(result, Is.Not.Null);
        }
    }
}
