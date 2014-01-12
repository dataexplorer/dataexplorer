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
    public class IntegerPredicateTests
    {
        private IntegerPredicate _predicate;
        private Column _column;
        private int _lowerValue;
        private int _upperValue;
        private List<Row> _rows;

        [SetUp]
        public void SetUp()
        {
            _lowerValue = int.MinValue + 1;
            _upperValue = int.MaxValue - 1;
            _rows = new List<Row>();
            _column = new ColumnBuilder().Build();
            _predicate = new IntegerPredicate();
        }

        [Test]
        public void TestPredicateShouldExcludeNullValues()
        {
            AssertResult(null, false);
        }

        [Test]
        public void TestPredicateShouldExcludeRowsBelowTheLowerValue()
        {
            AssertResult(int.MinValue, false);
        }

        [Test]
        public void TestPredicateShouldIncludeRowsEqualToLowerValue()
        {
            AssertResult(int.MinValue + 1, true);
        }

        [Test]
        public void TestPredicateShouldIncludeRowsBetweenLowerAndUpperValues()
        {
            AssertResult(0, true);
        }

        [Test]
        public void TestPredicateShouldIncludeRowsEqualToUpperValue()
        {
            AssertResult(int.MaxValue - 1, true);
        }

        [Test]
        public void TestPredicateShouldExcludeRowsAboveTheUpperValue()
        {
            AssertResult(int.MaxValue, false);
        }
        
        private void AssertResult(int? rowValue, bool isIncluded)
        {
            var row = new RowBuilder().WithField(rowValue).Build();
            _rows.Add(row);
            var predicate = _predicate.Create(_column, _lowerValue, _upperValue);
            var result = _rows.Where(predicate);
            Assert.That(result.Contains(row), Is.EqualTo(isIncluded));
        }
    }
}
