using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Filters.IntegerFilters;
using DataExplorer.Tests.Domain.Columns;
using NUnit.Framework;

namespace DataExplorer.Tests.Domain.Filters.IntegerFilters
{
    public class IntegerFilterTests
    {
        private IntegerFilter _filter;
        private Column _column;
        private int _lowerValue;
        private int _upperValue;

        [SetUp]
        public void SetUp()
        {
            _lowerValue = int.MinValue;
            _upperValue = int.MaxValue;
            _column = new ColumnBuilder().Build();
            _filter = new IntegerFilter(_column, _lowerValue, _upperValue);
        }

        [Test]
        public void TestGetLowerValueShouldReturnLowerValue()
        {
            var result = _filter.LowerValue;
            Assert.That(result, Is.EqualTo(_lowerValue));
        }

        [Test]
        public void TestGetUpperValueShouldReturnLowerValue()
        {
            var result = _filter.UpperValue;
            Assert.That(result, Is.EqualTo(_upperValue));
        }

        [Test]
        public void TestCreatePredicateShouldReturnPredicate()
        {
            var result = _filter.CreatePredicate();
            Assert.That(result, Is.Not.Null);
        }
    }
}
