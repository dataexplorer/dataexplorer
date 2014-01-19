using System;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Filters;
using DataExplorer.Domain.Tests.Columns;
using NUnit.Framework;

namespace DataExplorer.Domain.Tests.Filters
{
    [TestFixture]
    public class DateTimeFilterTests
    {
        private DateTimeFilter _filter;
        private Column _column;
        private DateTime _value;
        private bool _includeNull;
        
        [SetUp]
        public void SetUp()
        {
            _value = new DateTime(2001, 01, 01);
            _includeNull = true;
            _column = new ColumnBuilder().Build();
            _filter = new DateTimeFilter(_column, DateTime.MinValue, DateTime.MaxValue, _includeNull);
        }

        [Test]
        public void TestGetSetLowerValueShouldGetSetLowerValue()
        {
            _filter.LowerValue = _value;
            var result = _filter.LowerValue;
            Assert.That(result, Is.EqualTo(_value));
        }

        [Test]
        public void TestGetSetUpperValueShouldGetSetUpperValue()
        {
            _filter.UpperValue = _value;
            var result = _filter.UpperValue;
            Assert.That(result, Is.EqualTo(_value));
        }

        [Test]
        public void TestCreatePredicateShouldReturnBooleanPredicate()
        {
            var result = _filter.CreatePredicate();
            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public void TestCreatePredicateShouldReturnNullableBooleanPredicate()
        {
            var column = new ColumnBuilder().WithNulls().Build();
            _filter = new DateTimeFilter(column, DateTime.MinValue, DateTime.MaxValue, true);
            var result = _filter.CreatePredicate();
            Assert.That(result, Is.Not.Null);
        }
    }
}
