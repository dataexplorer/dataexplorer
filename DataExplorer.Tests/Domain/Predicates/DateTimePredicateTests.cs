using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Predicates;
using DataExplorer.Domain.Rows;
using DataExplorer.Tests.Domain.Columns;
using DataExplorer.Tests.Domain.Rows;
using NUnit.Framework;

namespace DataExplorer.Tests.Domain.Predicates
{
    [TestFixture]
    public class DateTimePredicateTests
    {
        private DateTimePredicate _predicate;
        private Column _column;
        private DateTime _lowerValue;
        private DateTime _upperValue;
        private List<Row> _rows;
        
        [SetUp]
        public void SetUp()
        {
            _lowerValue = DateTime.MinValue.AddTicks(1);
            _upperValue = DateTime.MaxValue.AddTicks(-1);
            _rows = new List<Row>();
            _column = new ColumnBuilder().Build();
            _predicate = new DateTimePredicate();
        }
        
        [Test]
        public void TestPredicateShouldExcludeNullValues()
        {
            AssertResult(null, false);
        }

        [Test]
        public void TestPredicateShouldIncludeRowsBetweenLowerAndUpperValues()
        {
            AssertResult(new DateTime(2000, 1, 1), true);
        }

        [Test]
        public void TestPredicateShouldExcludeRowsBelowTheLowerValue()
        {
            AssertResult(DateTime.MinValue, false);
        }

        [Test]
        public void TestPredicateShouldExcludeRowsAboveTheUpperValue()
        {
            AssertResult(DateTime.MaxValue, false);
        }

        private void AssertResult(DateTime? rowValue, bool isIncluded)
        {
            var row = new RowBuilder().WithField(rowValue).Build();
            _rows.Add(row);
            var predicate = _predicate.Create(_column, _lowerValue, _upperValue);
            var result = _rows.Where(predicate);
            Assert.That(result.Contains(row), Is.EqualTo(isIncluded));
        }
    }
}
