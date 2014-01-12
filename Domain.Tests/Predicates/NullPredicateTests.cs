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
    public class NullPredicateTests
    {
        private NullPredicate _predicate;
        private Column _column;
        private List<Row> _rows;

        [SetUp]
        public void SetUp()
        {
            _rows = new List<Row>();
            _column = new ColumnBuilder().Build();
            _predicate = new NullPredicate();
        }

        [Test]
        public void TestPredicateWithNullShouldIncludeNullRows()
        {
            AssertResult(null, true);
        }

        [Test]
        public void TestPredicateWithFalseShouldExcludeNotNullRows()
        {
            AssertResult(new object(), false);
        }
        
        private void AssertResult(object rowValue, bool isExpected)
        {
            var row = new RowBuilder().WithField(rowValue).Build();
            _rows.Add(row);
            var predicate = _predicate.Create(_column);
            var result = _rows.Where(predicate);
            Assert.That(result.Contains(row), Is.EqualTo(isExpected));
        }
    }
}
