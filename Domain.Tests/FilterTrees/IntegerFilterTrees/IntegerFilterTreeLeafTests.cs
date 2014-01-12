using DataExplorer.Domain.FilterTrees.IntegerFilterTrees;
using DataExplorer.Domain.Tests.Columns;
using NUnit.Framework;

namespace DataExplorer.Domain.Tests.FilterTrees.IntegerFilterTrees
{
    [TestFixture]
    public class IntegerFilterTreeLeafTests
    {
        [Test]
        public void TestGetChildrenShouldReturnEmptyList()
        {
            var column = new ColumnBuilder().Build();
            var leaf = new IntegerFilterTreeLeaf(string.Empty, column, 0);
            var result = leaf.CreateChildren();
            Assert.That(result, Is.Empty);
        }
    }
}
