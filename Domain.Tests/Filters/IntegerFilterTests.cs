using System;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Filters;
using DataExplorer.Domain.Tests.Columns;
using NUnit.Framework;

namespace DataExplorer.Domain.Tests.Filters
{
    public class IntegerFilterTests
    {
        private IntegerFilter _filter;
        private Column _column;

        [SetUp]
        public void SetUp()
        {
            _column = new ColumnBuilder().Build();
            _filter = new IntegerFilter(_column, Int32.MinValue, Int32.MaxValue, false);
        }

        [Test]
        public void TestGetSetLowerValueShouldGetSetLowerValue()
        {
            _filter.LowerValue = 1;
            var result = _filter.LowerValue;
            Assert.That(result, Is.EqualTo(1));
        }

        [Test]
        public void TestGetSetUpperValueShouldGetSetLowerValue()
        {
            _filter.UpperValue = 1;
            var result = _filter.UpperValue;
            Assert.That(result, Is.EqualTo(1));
        }

        [Test]
        public void TestCreatePredicateShouldReturnPredicate()
        {
            var result = _filter.CreatePredicate();
            Assert.That(result, Is.Not.Null);
        }
    }
}
