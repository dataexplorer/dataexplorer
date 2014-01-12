using System;
using DataExplorer.Domain.FilterTrees.DateTimeFilterTrees;
using DataExplorer.Domain.Tests.Columns;
using NUnit.Framework;

namespace DataExplorer.Domain.Tests.FilterTrees.DateTimeFilterTrees
{
    [TestFixture]
    public class SecondFilterTreeNodeTests
    {
        [Test]
        public void TestCreateChildrenShouldReturnEmptyList()
        {
            var column = new ColumnBuilder().Build();
            var node = new SecondFilterTreeNode(string.Empty, column, DateTime.MinValue, DateTime.MaxValue);
            var result = node.CreateChildren();
            Assert.That(result, Is.Empty);
        }
    }
}
