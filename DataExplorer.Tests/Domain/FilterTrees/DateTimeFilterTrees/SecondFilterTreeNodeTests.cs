using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.FilterTrees.DateTimeFilterTrees;
using DataExplorer.Tests.Domain.Columns;
using NUnit.Framework;

namespace DataExplorer.Tests.Domain.FilterTrees.DateTimeFilterTrees
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
