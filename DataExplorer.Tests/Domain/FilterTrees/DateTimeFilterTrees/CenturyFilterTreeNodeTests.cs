using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.FilterTrees.DateTimeFilterTrees;
using DataExplorer.Tests.Domain.Columns;
using NUnit.Framework;

namespace DataExplorer.Tests.Domain.FilterTrees.DateTimeFilterTrees
{
    [TestFixture]
    public class CenturyFilterTreeNodeTests
    {
        [Test]
        public void TestCreateChildrenShouldCreateMinDecade()
        {
            var lower = DateTime.MinValue;
            var upper = DateTime.MinValue.AddDays(3652);
            var column = new ColumnBuilder().WithValue(lower).WithValue(upper).Build();
            var node = new CenturyFilterTreeNode(string.Empty, column, lower, upper);
            var result = node.CreateChildren();
            Assert.That(result.First().Name, Is.EqualTo("00s"));
            //TODO: Assert value
        }

        [Test]
        public void TestCreateChildrenShouldCreateMaxDecade()
        {
            var lower = DateTime.MaxValue.AddDays(-3652);
            var upper = DateTime.MaxValue;
            var column = new ColumnBuilder().WithValue(lower).WithValue(upper).Build();
            var node = new CenturyFilterTreeNode(string.Empty, column, lower, upper);
            var result = node.CreateChildren();
            Assert.That(result.Last().Name, Is.EqualTo("9990s"));
            //TODO: Assert value
        }

        [Test]
        public void TestCreateChildrenShouldCreateMidDecade()
        {
            var lower = new DateTime(5550, 1, 1);
            var upper = new DateTime(5560, 1, 1);
            var column = new ColumnBuilder().WithValue(lower).WithValue(upper).Build();
            var node = new CenturyFilterTreeNode(string.Empty, column, lower, upper);
            var result = node.CreateChildren();
            Assert.That(result.First().Name, Is.EqualTo("5550s"));
            //TODO: Assert value
        }
    }
}
