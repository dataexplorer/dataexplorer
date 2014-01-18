using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Filters;
using DataExplorer.Domain.Tests.Columns;
using NUnit.Framework;

namespace DataExplorer.Domain.Tests.Filters
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
            _filter = new BooleanFilter(_column, false, false, false);
        }

        [Test]
        public void TestIncludeTrue()
        {
            _filter.IncludeTrue = true;
            Assert.That(_filter.IncludeTrue, Is.True);
        }

        [Test]
        public void TestIncludeFalse()
        {
            _filter.IncludeFalse = true;
            Assert.That(_filter.IncludeFalse, Is.True);
        }

        [Test]
        public void TestCreatePredicateShouldReturnBooleanPredicate()
        {
            var result = _filter.CreatePredicate();
            Assert.That(result, Is.Not.Null);
        }
    }
}
