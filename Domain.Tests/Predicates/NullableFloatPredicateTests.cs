using System.Collections.Generic;
using System.Linq;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Predicates;
using DataExplorer.Domain.Rows;
using DataExplorer.Domain.Tests.Columns;
using DataExplorer.Domain.Tests.Rows;
using NUnit.Framework;

namespace DataExplorer.Domain.Tests.Predicates
{
    [TestFixture]
    public class NullableFloatPredicateTests
    {
        private NullableFloatPredicate _predicate;
        private Column _column;
        private List<Row> _rows;
        private double _lowerValue;
        private double _upperValue;

        [SetUp]
        public void SetUp()
        {
            _lowerValue = double.MinValue;
            _upperValue = double.MaxValue;
            _rows = new List<Row>();
            _column = new ColumnBuilder().Build();
            _predicate = new NullableFloatPredicate();
        }

        [Test]
        public void TestPredicateShouldIncludeNullsIfSpecified()
        {
            AssertResult(null, true, true);
        }

        [Test]
        public void TestPredicateShouldNotIncludeNullsIfNotSpecified()
        {
            AssertResult(null, false, false);
        }

        [Test]
        public void TestPredicateShouldDelegateNonNullValuesToFloatPredicate()
        {
            AssertResult(0d, true, true);
        }

        private void AssertResult(double? rowValue, bool includeNulls, bool isExpected)
        {
            var row = new RowBuilder().WithField(rowValue).Build();
            _rows.Add(row);
            var predicate = _predicate.Create(_column, _lowerValue, _upperValue, includeNulls);
            var result = _rows.Where(predicate);
            Assert.That(result.Contains(row), Is.EqualTo(isExpected));
        }
    }
}
