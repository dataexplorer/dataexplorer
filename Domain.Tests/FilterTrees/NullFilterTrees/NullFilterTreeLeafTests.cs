using DataExplorer.Domain.Columns;
using DataExplorer.Domain.FilterTrees.NullFilterTrees;
using DataExplorer.Domain.Tests.Columns;
using NUnit.Framework;

namespace DataExplorer.Domain.Tests.FilterTrees.NullFilterTrees
{
    [TestFixture]
    public class NullFilterTreeLeafTests
    {
        private NullFilterTreeLeaf _leaf;
        private Column _column;

        [SetUp]
        public void SetUp()
        {
            _column = new ColumnBuilder().Build();
            _leaf = new NullFilterTreeLeaf(string.Empty, _column);
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
            var result = _leaf.CreateFilter();
            Assert.That(result, Is.Not.Null);
        }
    }
}
