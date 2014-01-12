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
    public class BooleanPredicateTests
    {
        private BooleanPredicate _predicate;
        private Column _column;
        private List<bool?> _values;
        private List<Row> _rows; 
        private Row _nullRow;
        private Row _falseRow;
        private Row _trueRow;

        [SetUp]
        public void SetUp()
        {
            _nullRow = new RowBuilder().WithField(null).Build();
            _falseRow = new RowBuilder().WithField(false).Build();
            _trueRow = new RowBuilder().WithField(true).Build();
            _rows = new List<Row> { _nullRow, _falseRow, _trueRow };
            _values = new List<bool?>();
            _column = new ColumnBuilder().Build();
            _predicate = new BooleanPredicate();
        }

        [Test]
        public void TestEmptyPredicateShouldReturnAllValues()
        {
            _values.AddRange(new List<bool?> { null, false, true });
            var predicate = _predicate.Create(_column, _values);
            var result = _rows.Where(predicate);
            Assert.That(result.Count(), Is.EqualTo(3));
        }

        [Test]
        public void TestPredicateWithNullShouldIncludeNullRows()
        {
            AssertResult(null, _nullRow);
        }

        [Test]
        public void TestPredicateWithFalseShouldIncludeFalseRows()
        {
            AssertResult(false, _falseRow);
        }

        [Test]
        public void TestPredicateWithTrueShouldIncludeTrueRows()
        {
            AssertResult(true, _trueRow);
        }

        private void AssertResult(bool? value, Row resultRow)
        {
            _values.Add(value);
            var predicate = _predicate.Create(_column, _values);
            var result = _rows.Where(predicate);
            Assert.That(result.Single(), Is.EqualTo(resultRow));
        }
    }
}
