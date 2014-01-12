using DataExplorer.Domain.FilterTrees.FloatFilterTrees;
using DataExplorer.Domain.Tests.Columns;
using NUnit.Framework;

namespace DataExplorer.Domain.Tests.FilterTrees.FloatFilterTrees
{
    [TestFixture]
    public class FloatFilterTreeLeafTests
    {
        [Test]
        public void TestCreateChildrenShouldReturnEmptyList()
        {
            var column = new ColumnBuilder().Build();
            var leaf = new FloatFilterTreeLeaf(string.Empty, column, 0d);
            var result = leaf.CreateChildren();
            Assert.That(result, Is.Empty);
        }

    }
}
