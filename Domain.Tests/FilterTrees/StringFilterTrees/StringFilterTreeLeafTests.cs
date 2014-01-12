using DataExplorer.Domain.FilterTrees.StringFilterTrees;
using DataExplorer.Domain.Tests.Columns;
using NUnit.Framework;

namespace DataExplorer.Domain.Tests.FilterTrees.StringFilterTrees
{
    [TestFixture]
    public class StringFilterTreeLeafTests
    {
        [Test]
        public void TestCreateChildrenShouldReturnEmptyList()
        {
            var column = new ColumnBuilder().Build();
            var leaf = new StringFilterTreeLeaf(string.Empty, column, string.Empty, 1);
            var result = leaf.CreateChildren();
            Assert.That(result, Is.Empty);
        }
    }
}
