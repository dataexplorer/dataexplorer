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
    public class StringPredicateTests
    {
        private StringPredicate _predicate;
        private Column _column;
        private List<Row> _rows; 
        private string _value;

        [SetUp]
        public void SetUp()
        {
            _value = "ab";
            _rows = new List<Row>();
            _column = new ColumnBuilder().Build();
            _predicate = new StringPredicate();
        }

        [Test]
        public void TestPredicateShouldExcludeNullValues()
        {
            AssertResult(null, false);
        }

        [Test]
        public void TestPredicateShouldExcludeValuesNotStartingWithTheFilterValue()
        {
            AssertResult("z", false);
        }

        [Test]
        public void TestPredicateShouldExcludeValuesNotEntirelyStartingWithTheFilterValue()
        {
            AssertResult("a", false);
        }

        [Test]
        public void TestPredicateShouldIncludeValuesEqualingTheFilterValue()
        {
            AssertResult("ab", true);
        }

        [Test]
        public void TestPredicateShouldIncludeValuesStartingWithTheFilterValue()
        {
            AssertResult("abc", true);
        }

        private void AssertResult(string rowValue, bool isIncluded)
        {
            var row = new RowBuilder().WithField(rowValue).Build();
            _rows.Add(row);
            var predicate = _predicate.Create(_column, _value);
            var results = _rows.Where(predicate);
            Assert.That(results.Contains(row), Is.EqualTo(isIncluded));
        }
    }
}
