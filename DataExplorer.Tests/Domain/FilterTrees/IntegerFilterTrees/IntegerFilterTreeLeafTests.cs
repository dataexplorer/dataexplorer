using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.FilterTrees.IntegerFilterTrees;
using DataExplorer.Tests.Domain.Columns;
using NUnit.Framework;

namespace DataExplorer.Tests.Domain.FilterTrees.IntegerFilterTrees
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
