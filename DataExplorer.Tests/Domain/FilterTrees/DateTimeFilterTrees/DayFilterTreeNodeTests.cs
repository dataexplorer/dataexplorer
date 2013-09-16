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
    public class DayFilterTreeNodeTests
    {
        [Test]
        public void TestCreateChildrenShouldCreateMinDay()
        {
            var lower = DateTime.MinValue;
            var upper = DateTime.MinValue.AddHours(1);
            var column = new ColumnBuilder().WithValue(lower).WithValue(upper).Build();
            var node = new DayFilterTreeNode(string.Empty, column, lower, upper);
            var result = node.CreateChildren();
            Assert.That(result.First().Name, Is.EqualTo("12 AM"));
            //TODO: Assert value
        }

        [Test]
        public void TestCreateChildrenShouldCreateMaxDay()
        {
            var lower = DateTime.MaxValue.AddHours(-1);
            var upper = DateTime.MaxValue;
            var column = new ColumnBuilder().WithValue(lower).WithValue(upper).Build();
            var node = new DayFilterTreeNode(string.Empty, column, lower, upper);
            var result = node.CreateChildren();
            Assert.That(result.Last().Name, Is.EqualTo("11 PM"));
            //TODO: Assert value
        }

        [Test]
        public void TestCreateChildrenShouldCreateMidDay()
        {
            var lower = new DateTime(5555, 6, 15, 12, 0, 0);
            var upper = new DateTime(5555, 6, 15, 12, 0, 0);
            var column = new ColumnBuilder().WithValue(lower).WithValue(upper).Build();
            var node = new DayFilterTreeNode(string.Empty, column, lower, upper);
            var result = node.CreateChildren();
            Assert.That(result.First().Name, Is.EqualTo("12 PM"));
            //TODO: Assert value
        }
    }
}
