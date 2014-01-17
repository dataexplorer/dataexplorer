using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Filters.BooleanFilters;
using DataExplorer.Domain.FilterTrees.BooleanFilterTrees;
using DataExplorer.Domain.Tests.Columns;
using NUnit.Framework;

namespace DataExplorer.Domain.Tests.FilterTrees.BooleanFilterTrees
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
            Assert.That(result.IncludeTrue, Is.True);
            Assert.That(result.IncludeFalse, Is.False);
        }
    }
}
