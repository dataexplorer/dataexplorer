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
    public class FloatPredicateTests
    {
        private FloatPredicate _predicate;
        private Column _column;
        private double _lowerValue;
        private double _upperValue;
        private List<Row> _rows;

        [SetUp]
        public void SetUp()
        {
            _lowerValue = double.MinValue;
            _upperValue = double.MaxValue;
            _rows = new List<Row>();
            _column = new ColumnBuilder().Build();
            _predicate = new FloatPredicate();
        }

        [Test]
        public void TestPredicateShouldExcludeNullValues()
        {
            AssertResult(null, false);
        }

        [Test]
        public void TestPredicateShouldExcludeRowsBelowTheLowerValue()
        {
            AssertResult(double.NegativeInfinity, false);
        }

        [Test]
        public void TestPredicateShouldIncludeRowsEqualToLowerValue()
        {
            AssertResult(double.MinValue, true);
        }

        [Test]
        public void TestPredicateShouldIncludeRowsBetweenLowerAndUpperValues()
        {
            AssertResult(0d, true);
        }

        [Test]
        public void TestPredicateShouldIncludeRowsEqualToUpperValue()
        {
            AssertResult(double.MaxValue, true);
        }

        [Test]
        public void TestPredicateShouldExcludeRowsAboveTheUpperValue()
        {
            AssertResult(double.PositiveInfinity, false);
        }

        [Test]
        public void TestPredicateShouldExcludeNaNValues()
        {
            AssertResult(double.NaN, false);
        }

        private void AssertResult(double? rowValue, bool isIncluded)
        {
            var row = new RowBuilder().WithField(rowValue).Build();
            _rows.Add(row);
            var predicate = _predicate.Create(_column, _lowerValue, _upperValue);
            var result = _rows.Where(predicate);
            Assert.That(result.Contains(row), Is.EqualTo(isIncluded));
        }
    }
}
