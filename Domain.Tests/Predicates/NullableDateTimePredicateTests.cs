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
    public class NullableDateTimePredicateTests
    {
        private NullableDateTimePredicate _predicate;
        private Column _column;
        private List<Row> _rows; 
        private DateTime _lowerValue;
        private DateTime _upperValue;

        [SetUp]
        public void SetUp()
        {
            _lowerValue = DateTime.MinValue;
            _upperValue = DateTime.MaxValue;
            _rows = new List<Row>();
            _column = new ColumnBuilder().Build();
            _predicate = new NullableDateTimePredicate();
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
        public void TestPredicateShouldDelegateNonNullValuesToDateTimePredicate()
        {
            AssertResult(new DateTime(2000, 1, 1), true, true);
        }

        private void AssertResult(DateTime? rowValue, bool includeNulls, bool isExpected)
        {
            var row = new RowBuilder().WithField(rowValue).Build();
            _rows.Add(row);
            var predicate = _predicate.Create(_column, _lowerValue, _upperValue, includeNulls);
            var result = _rows.Where(predicate);
            Assert.That(result.Contains(row), Is.EqualTo(isExpected));
        }
    }
}
