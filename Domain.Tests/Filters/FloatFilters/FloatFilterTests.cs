using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Filters.FloatFilters;
using DataExplorer.Domain.Tests.Columns;
using NUnit.Framework;

namespace DataExplorer.Domain.Tests.Filters.FloatFilters
{
    public class FloatFilterTests
    {
        private FloatFilter _filter;
        private Column _column;
        private double _lowerValue;
        private double _upperValue;
        private bool _includeNull;

        [SetUp]
        public void SetUp()
        {
            _lowerValue = double.MinValue;
            _upperValue = double.MaxValue;
            _includeNull = true;
            _column = new ColumnBuilder().Build();
            _filter = new FloatFilter(_column, _lowerValue, _upperValue, _includeNull);
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

        [Test]
        public void TestCreatePredicateShouldReturnNullableBooleanPredicate()
        {
            var result = _filter.CreatePredicate();
            Assert.That(result, Is.Not.Null);
        }
    }
}
