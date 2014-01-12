using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.FilterTrees.BooleanFilterTrees;
using DataExplorer.Domain.Filters;
using DataExplorer.Domain.Filters.BooleanFilters;
using DataExplorer.Tests.Domain.Columns;
using NUnit.Framework;

namespace DataExplorer.Tests.Domain.FilterTrees.BooleanFilterTrees
{
    [TestFixture]
    public class BooleanFilterTreeLeafTests
    {
        private BooleanFilterTreeLeaf _leaf;
        private Column _column;

        [SetUp]
        public void SetUp()
        {
            _column = new ColumnBuilder().Build();
            _leaf = new BooleanFilterTreeLeaf("Test", _column, true);
        }
        
        [Test]
        public void TestConstructorShouldSetValue()
        {
            Assert.That(_leaf.Value, Is.EqualTo(true));
        }

        [Test]
        public void TestCreateChildrenShouldReturnEmptyList()
        {
            var result = _leaf.CreateChildren();
            Assert.That(result, Is.Empty);
        }

        [Test]
        public void TestCreateFilterShouldReturnFilter()
        {
            _leaf = new BooleanFilterTreeLeaf(string.Empty, _column, true);
            var result = (BooleanFilter) _leaf.CreateFilter();
            Assert.That(result.Values.Contains(true));
        }
    }
}
