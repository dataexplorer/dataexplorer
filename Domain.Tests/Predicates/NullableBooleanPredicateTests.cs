using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Predicates;
using DataExplorer.Domain.Rows;
using DataExplorer.Domain.Tests.Columns;
using DataExplorer.Domain.Tests.Rows;
using NUnit.Framework;

namespace DataExplorer.Domain.Tests.Predicates
{
    [TestFixture]
    public class NullableBooleanPredicateTests
    {
        private NullableBooleanPredicate _predicate;
        private Column _column;
        private List<Row> _rows; 
        private Row _nullRow;
        private Row _falseRow;
        private Row _trueRow;

        [SetUp]
        public void SetUp()
        {
            _nullRow = new RowBuilder().WithField((bool?) null).Build();
            _falseRow = new RowBuilder().WithField((bool?) false).Build();
            _trueRow = new RowBuilder().WithField((bool?) true).Build();
            _rows = new List<Row> { _nullRow, _falseRow, _trueRow };
            _column = new ColumnBuilder().Build();
            _predicate = new NullableBooleanPredicate();
        }

        [Test]
        public void TestEmptyPredicateShouldReturnAllValues()
        {
            var predicate = _predicate.Create(_column, true, true, true);
            var result = _rows.Where(predicate);
            Assert.That(result.Count(), Is.EqualTo(3));
        }

        [Test]
        public void TestPredicateWithFalseShouldIncludeFalseRows()
        {
            AssertResult(false, true, false, _falseRow);
        }

        [Test]
        public void TestPredicateWithTrueShouldIncludeTrueRows()
        {
            AssertResult(true, false, false, _trueRow);
        }

        [Test]
        public void TestPredicateWithNullShouldIncludeNullRows()
        {
            AssertResult(false, false, true, _nullRow);
        }

        private void AssertResult(bool includeTrue, bool includeFalse, bool includeNull, Row resultRow)
        {
            var predicate = _predicate.Create(_column, includeTrue, includeFalse, includeNull);
            var result = _rows.Where(predicate);
            Assert.That(result.Single(), Is.EqualTo(resultRow));
        }
    }
}
