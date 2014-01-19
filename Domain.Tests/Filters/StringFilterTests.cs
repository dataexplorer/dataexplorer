using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Filters;
using DataExplorer.Domain.Tests.Columns;
using NUnit.Framework;

namespace DataExplorer.Domain.Tests.Filters
{
    [TestFixture]
    public class StringFilterTests
    {
        private StringFilter _filter;
        private Column _column;
        
        [SetUp]
        public void SetUp()
        {
            _column = new ColumnBuilder().Build();
            _filter = new StringFilter(_column, string.Empty, false);
        }

        [Test]
        public void TestGetValueShouldReturnValue()
        {
            _filter.Value = "Test";
            var result = _filter.Value;
            Assert.That(result, Is.EqualTo("Test"));
        }

        [Test]
        public void TestCreatePredicateReturnsPredicate()
        {
            var result = _filter.CreatePredicate();
            Assert.That(result, Is.Not.Null);
        }
    }
}
