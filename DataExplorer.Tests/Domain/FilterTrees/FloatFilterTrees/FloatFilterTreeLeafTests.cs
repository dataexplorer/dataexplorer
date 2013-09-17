using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.FilterTrees.FloatFilterTrees;
using DataExplorer.Tests.Domain.Columns;
using NUnit.Framework;

namespace DataExplorer.Tests.Domain.FilterTrees.FloatFilterTrees
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
