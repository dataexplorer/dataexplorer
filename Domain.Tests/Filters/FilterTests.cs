using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Filters;
using DataExplorer.Domain.Tests.Columns;
using NUnit.Framework;

namespace DataExplorer.Domain.Tests.Filters
{
    [TestFixture]
    public class FilterTests
    {
        private Filter _filter;
        private Column _column;

        [SetUp]
        public void SetUp()
        {
            _column = new ColumnBuilder().Build();

            _filter = new FakeFilter(_column);
        }

        [Test]
        public void TestGetColumnShouldReturnColumn()
        {
            var result = _filter.Column;
            Assert.That(result, Is.EqualTo(_column));
        }
    }
}
