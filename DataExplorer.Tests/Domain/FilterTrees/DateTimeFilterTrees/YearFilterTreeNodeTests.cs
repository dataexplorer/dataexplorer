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
    public class YearFilterTreeNodeTests
    {
        [Test]
        public void TestCreateChildrenShouldCreateMinYear()
        {
            var lower = DateTime.MinValue;
            var upper = DateTime.MinValue.AddDays(30);
            var column = new ColumnBuilder().WithValue(lower).WithValue(upper).Build();
            var node = new YearFilterTreeNode(string.Empty, column, lower, upper);
            var result = node.CreateChildren();
            Assert.That(result.First().Name, Is.EqualTo("Jan"));
            //TODO: Assert value
        }

        [Test]
        public void TestCreateChildrenShouldCreateMaxYear()
        {
            var lower = DateTime.MaxValue.AddDays(-30);
            var upper = DateTime.MaxValue;
            var column = new ColumnBuilder().WithValue(lower).WithValue(upper).Build();
            var node = new YearFilterTreeNode(string.Empty, column, lower, upper);
            var result = node.CreateChildren();
            Assert.That(result.Last().Name, Is.EqualTo("Dec"));
            //TODO: Assert value
        }

        [Test]
        public void TestCreateChildrenShouldCreateMidYear()
        {
            var lower = new DateTime(5555, 6, 1);
            var upper = new DateTime(5555, 7, 1);
            var column = new ColumnBuilder().WithValue(lower).WithValue(upper).Build();
            var node = new YearFilterTreeNode(string.Empty, column, lower, upper);
            var result = node.CreateChildren();
            Assert.That(result.First().Name, Is.EqualTo("Jun"));
            //TODO: Assert value
        }
    }
}
