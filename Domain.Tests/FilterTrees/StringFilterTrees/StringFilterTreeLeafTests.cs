using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.FilterTrees.StringFilterTrees;
using DataExplorer.Tests.Domain.Columns;
using NUnit.Framework;

namespace DataExplorer.Tests.Domain.FilterTrees.StringFilterTrees
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
