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
            Test(lower, upper, 0, "12 AM");
        }

        [Test]
        public void TestCreateChildrenShouldCreateMidDay()
        {
            var lower = new DateTime(5555, 6, 15, 12, 0, 0);
            var upper = new DateTime(5555, 6, 15, 12, 0, 0);
            Test(lower, upper, 0, "12 PM");
        }

        [Test]
        public void TestCreateChildrenShouldCreateMaxDay()
        {
            var lower = DateTime.MaxValue.AddHours(-1);
            var upper = DateTime.MaxValue;
            Test(lower, upper, 1, "11 PM");
        }

        private void Test(DateTime lower, DateTime upper, int index, string name)
        {
            var column = new ColumnBuilder().WithValue(lower).WithValue(upper).Build();
            var node = new DayFilterTreeNode(string.Empty, column, lower, upper);
            var result = node.CreateChildren();
            Assert.That(result.ElementAt(index).Name, Is.EqualTo(name));
            //TODO: Test value
        }
    }
}
