using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Filters;
using DataExplorer.Tests.Domain.Columns;
using NUnit.Framework;

namespace DataExplorer.Tests.Domain.Filters
{
    [TestFixture]
    public class DateTimeFilterTests
    {
        private DateTimeFilter _filter;
        private Column _column;
        private DateTime _lowerValue;
        private DateTime _upperValue;

        [SetUp]
        public void SetUp()
        {
            _lowerValue = DateTime.MinValue;
            _upperValue = DateTime.MaxValue;
            _column = new ColumnBuilder().Build();
            _filter = new DateTimeFilter(_column, _lowerValue, _upperValue);
        }

        [Test]
        public void TestGetLowerValueShouldReturnLowerValue()
        {
            var result = _filter.LowerValue;
            Assert.That(result, Is.EqualTo(_lowerValue));
        }

        [Test]
        public void TestGetUpperValueShouldReturnUpperValue()
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
