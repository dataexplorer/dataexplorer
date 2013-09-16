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
    public class MinuteFilterTreeNodeTests
    {
        [Test]
        public void TestCreateChildrenShouldCreateMinDay()
        {
            var lower = DateTime.MinValue;
            var upper = DateTime.MinValue.AddSeconds(1);
            var column = new ColumnBuilder().WithValue(lower).WithValue(upper).Build();
            var node = new MinuteFilterTreeNode(string.Empty, column, lower, upper);
            var result = node.CreateChildren();
            Assert.That(result.First().Name, Is.EqualTo("12:00:00"));
            //TODO: Assert value
        }

        [Test]
        public void TestCreateChildrenShouldCreateMaxDay()
        {
            var lower = DateTime.MaxValue.AddSeconds(-1);
            var upper = DateTime.MaxValue;
            var column = new ColumnBuilder().WithValue(lower).WithValue(upper).Build();
            var node = new MinuteFilterTreeNode(string.Empty, column, lower, upper);
            var result = node.CreateChildren();
            Assert.That(result.Last().Name, Is.EqualTo("11:59:59"));
            //TODO: Assert value
        }

        [Test]
        public void TestCreateChildrenShouldCreateMidDay()
        {
            var lower = new DateTime(5555, 6, 15, 12, 30, 30);
            var upper = new DateTime(5555, 6, 15, 12, 30, 31);
            var column = new ColumnBuilder().WithValue(lower).WithValue(upper).Build();
            var node = new MinuteFilterTreeNode(string.Empty, column, lower, upper);
            var result = node.CreateChildren();
            Assert.That(result.First().Name, Is.EqualTo("12:30:30"));
            //TODO: Assert value
        }
    }
}
