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
            Test(lower, upper, 0, "12:00:00");
        }

        [Test]
        public void TestCreateChildrenShouldCreateMidDay()
        {
            var lower = new DateTime(5555, 6, 15, 12, 30, 30);
            var upper = new DateTime(5555, 6, 15, 12, 30, 31);
            Test(lower, upper, 0, "12:30:30");
        }

        [Test]
        public void TestCreateChildrenShouldCreateMaxDay()
        {
            var lower = DateTime.MaxValue.AddSeconds(-1);
            var upper = DateTime.MaxValue;
            Test(lower, upper, 1, "11:59:59");
        }

        private void Test(DateTime lower, DateTime upper, int index, string name)
        {
            var column = new ColumnBuilder().WithValue(lower).WithValue(upper).Build();
            var node = new MinuteFilterTreeNode(string.Empty, column, lower, upper);
            var result = node.CreateChildren();
            Assert.That(result.ElementAt(index).Name, Is.EqualTo(name));
            //TODO: Test value
        }
    }
}
