using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Filters;
using DataExplorer.Tests.Domain.Columns;
using NUnit.Framework;

namespace DataExplorer.Tests.Domain.Filters
{
    [TestFixture]
    public class StringFilterTests
    {
        private StringFilter _filter;
        private Column _column;
        private string _value;

        [SetUp]
        public void SetUp()
        {
            _value = "Test";
            _column = new ColumnBuilder().Build();
            _filter = new StringFilter(_column, _value);
        }

        [Test]
        public void TestGetValueShouldReturnValue()
        {
            var result = _filter.Value;
            Assert.That(result, Is.EqualTo(_value));
        }

        [Test]
        public void TestCreatePredicateReturnsPredicate()
        {
            var result = _filter.CreatePredicate();
            Assert.That(result, Is.Not.Null);
        }
    }
}
