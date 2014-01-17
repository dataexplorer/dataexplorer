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
    public class BooleanPredicateTests
    {
        private BooleanPredicate _predicate;
        private Column _column;
        private List<bool?> _values;
        private List<Row> _rows; 
        private Row _falseRow;
        private Row _trueRow;

        [SetUp]
        public void SetUp()
        {
            _falseRow = new RowBuilder().WithField(false).Build();
            _trueRow = new RowBuilder().WithField(true).Build();
            _rows = new List<Row> { _falseRow, _trueRow };
            _values = new List<bool?>();
            _column = new ColumnBuilder().Build();
            _predicate = new BooleanPredicate();
        }

        [Test]
        public void TestEmptyPredicateShouldReturnAllValues()
        {
            var predicate = _predicate.Create(_column, true, true);
            var result = _rows.Where(predicate);
            Assert.That(result.Count(), Is.EqualTo(2));
        }

        [Test]
        public void TestPredicateWithFalseShouldIncludeFalseRows()
        {
            AssertResult(false, true, _falseRow);
        }

        [Test]
        public void TestPredicateWithTrueShouldIncludeTrueRows()
        {
            AssertResult(true, false, _trueRow);
        }

        private void AssertResult(bool includeTrue, bool includeFalse, Row resultRow)
        {
            var predicate = _predicate.Create(_column, includeTrue, includeFalse);
            var result = _rows.Where(predicate);
            Assert.That(result.Single(), Is.EqualTo(resultRow));
        }
    }
}
