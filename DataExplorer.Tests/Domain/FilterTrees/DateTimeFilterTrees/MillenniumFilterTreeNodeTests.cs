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
    public class MillenniumFilterTreeNodeTests
    {
        [Test]
        public void TestCreateChildrenShouldCreateMinCentury()
        {
            var lower = DateTime.MinValue;
            var upper = DateTime.MinValue.AddDays(36524);
            var column = new ColumnBuilder().WithValue(lower).WithValue(upper).Build();
            var node = new MillenniumFilterTreeNode(string.Empty, column, lower, upper);
            var result = node.CreateChildren();
            Assert.That(result.First().Name, Is.EqualTo("000s"));
            //TODO: Assert value
        }

        [Test]
        public void TestCreateChildrenShouldCreateMaxCentury()
        {
            var lower = DateTime.MaxValue.AddDays(-36524);
            var upper = DateTime.MaxValue;
            var column = new ColumnBuilder().WithValue(lower).WithValue(upper).Build();
            var node = new MillenniumFilterTreeNode(string.Empty, column, lower, upper);
            var result = node.CreateChildren();
            Assert.That(result.Last().Name, Is.EqualTo("9900s"));
            //TODO: Assert value
        }

        [Test]
        public void TestCreateChildrenShouldCreateMidCentury()
        {
            var lower = new DateTime(5500, 1, 1);
            var upper = new DateTime(5600, 1, 1);
            var column = new ColumnBuilder().WithValue(lower).WithValue(upper).Build();
            var node = new MillenniumFilterTreeNode(string.Empty, column, lower, upper);
            var result = node.CreateChildren();
            Assert.That(result.First().Name, Is.EqualTo("5500s"));
            //TODO: Assert value
        }
    }
}
