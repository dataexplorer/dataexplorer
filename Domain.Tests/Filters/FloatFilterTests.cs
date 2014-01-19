using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Filters;
using DataExplorer.Domain.Tests.Columns;
using NUnit.Framework;

namespace DataExplorer.Domain.Tests.Filters
{
    public class FloatFilterTests
    {
        private FloatFilter _filter;
        private Column _column;
        private bool _includeNull;

        [SetUp]
        public void SetUp()
        {
            _includeNull = true;
            _column = new ColumnBuilder().Build();
            _filter = new FloatFilter(_column, double.MinValue, double.MaxValue, _includeNull);
        }

        [Test]
        public void TestGetSetLowerValueShouldGetSetLowerValue()
        {
            _filter.LowerValue = 0.5;
            var result = _filter.LowerValue;
            Assert.That(result, Is.EqualTo(0.5));
        }

        [Test]
        public void TestGetSetUpperValueShouldGetSetLowerValue()
        {
            _filter.UpperValue = 0.5;
            var result = _filter.UpperValue;
            Assert.That(result, Is.EqualTo(0.5));
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
