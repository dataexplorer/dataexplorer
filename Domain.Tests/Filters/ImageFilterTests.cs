using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Filters;
using DataExplorer.Domain.Tests.Columns;
using NUnit.Framework;

namespace DataExplorer.Domain.Tests.Filters
{
    [TestFixture]
    public class ImageFilterTests
    {
        private ImageFilter _filter;
        private Column _column;
        
        [SetUp]
        public void SetUp()
        {
            _column = new ColumnBuilder().Build();
            _filter = new ImageFilter(_column, false, false);
        }

        [Test]
        public void TestIncludeNotNull()
        {
            _filter.IncludeNotNull = true;
            Assert.That(_filter.IncludeNotNull, Is.True);
        }

        [Test]
        public void TestCreatePredicateShouldReturnBooleanPredicate()
        {
            var result = _filter.CreatePredicate();
            Assert.That(result, Is.Not.Null);
        }
    }
}
