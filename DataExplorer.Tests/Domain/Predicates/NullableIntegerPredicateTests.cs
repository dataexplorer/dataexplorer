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
    public class NullableIntegerPredicateTests
    {
        private NullableIntegerPredicate _predicate;
        private Column _column;
        private List<Row> _rows;
        private int _lowerValue;
        private int _upperValue;

        [SetUp]
        public void SetUp()
        {
            _lowerValue = int.MinValue;
            _upperValue = int.MaxValue;
            _rows = new List<Row>();
            _column = new ColumnBuilder().Build();
            _predicate = new NullableIntegerPredicate();
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
        public void TestPredicateShouldDelegateNonNullValuesToIntegerPredicate()
        {
            AssertResult(0, true, true);
        }

        private void AssertResult(int? rowValue, bool includeNulls, bool isExpected)
        {
            var row = new RowBuilder().WithField(rowValue).Build();
            _rows.Add(row);
            var predicate = _predicate.Create(_column, _lowerValue, _upperValue, includeNulls);
            var result = _rows.Where(predicate);
            Assert.That(result.Contains(row), Is.EqualTo(isExpected));
        }
    }
}
