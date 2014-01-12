using System;
using System.Linq;
using DataExplorer.Domain.FilterTrees.DateTimeFilterTrees;
using DataExplorer.Domain.Tests.Columns;
using NUnit.Framework;

namespace DataExplorer.Domain.Tests.FilterTrees.DateTimeFilterTrees
{
    [TestFixture]
    public class HourFilterTreeNodeTests
    {
        [Test]
        public void TestCreateChildrenShouldCreateMinDay()
        {
            var lower = DateTime.MinValue;
            var upper = DateTime.MinValue.AddMinutes(1);
            Test(lower, upper, 0, "12:00");
        }

        [Test]
        public void TestCreateChildrenShouldCreateMidDay()
        {
            var lower = new DateTime(5555, 6, 15, 12, 30, 0);
            var upper = new DateTime(5555, 6, 15, 12, 31, 0);
            Test(lower, upper, 0, "12:30");
        }

        [Test]
        public void TestCreateChildrenShouldCreateMaxDay()
        {
            var lower = DateTime.MaxValue.AddMinutes(-1);
            var upper = DateTime.MaxValue;
            Test(lower, upper, 1, "11:59");
        }

        private void Test(DateTime lower, DateTime upper, int index, string name)
        {
            var column = new ColumnBuilder().WithValue(lower).WithValue(upper).Build();
            var node = new HourFilterTreeNode(string.Empty, column, lower, upper);
            var result = node.CreateChildren();
            Assert.That(result.ElementAt(index).Name, Is.EqualTo(name));
            //TODO: Test value
        }
    }
}
