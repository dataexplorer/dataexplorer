using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Predicates;
using DataExplorer.Domain.Rows;
using DataExplorer.Domain.Tests.Columns;
using DataExplorer.Domain.Tests.Rows;
using NUnit.Framework;

namespace DataExplorer.Domain.Tests.Predicates
{
    [TestFixture]
    public class ImagePredicateTests
    {
        private ImagePredicate _predicate;
        private Column _column;
        private List<Row> _rows;
        private Row _nullRow;
        private Row _notNullRow;
        
        [SetUp]
        public void SetUp()
        {
            _nullRow = new RowBuilder()
                .WithField((BitmapImage) null)
                .Build();
            _notNullRow = new RowBuilder()
                .WithField(new BitmapImage())
                .Build();
            _rows = new List<Row> { _nullRow, _notNullRow };
            _column = new ColumnBuilder().Build();
            _predicate = new ImagePredicate();
        }

        [Test]
        public void TestEmptyPredicateShouldReturnAllValues()
        {
            var predicate = _predicate.Create(_column, true, true);
            var result = _rows.Where(predicate);
            Assert.That(result.Count(), Is.EqualTo(2));
        }

        [Test]
        public void TestPredicateWithNullShouldIncludeNullRows()
        {
            AssertResult(true, false, _nullRow);
        }

        [Test]
        public void TestPredicateWithNotNullShouldIncludeNotNullRows()
        {
            AssertResult(false, true, _notNullRow);
        }

        private void AssertResult(bool includeNull, bool includeNotNull, Row resultRow)
        {
            var predicate = _predicate.Create(_column, includeNull, includeNotNull);
            var result = _rows.Where(predicate);
            Assert.That(result.Single(), Is.EqualTo(resultRow));
        }
    }
}
