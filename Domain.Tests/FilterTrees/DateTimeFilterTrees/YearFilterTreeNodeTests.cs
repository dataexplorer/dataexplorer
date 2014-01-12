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
            Test(lower, upper, 0, "Jan");
        }

        [Test]
        public void TestCreateChildrenShouldCreateMidYear()
        {
            var lower = new DateTime(5555, 6, 1);
            var upper = new DateTime(5555, 7, 1);
            Test(lower, upper, 0, "Jun");
        }

        [Test]
        public void TestCreateChildrenShouldCreateMaxYear()
        {
            var lower = DateTime.MaxValue.AddDays(-31);
            var upper = DateTime.MaxValue;
            Test(lower, upper, 1, "Dec");
        }

        private void Test(DateTime lower, DateTime upper, int index, string name)
        {
            var column = new ColumnBuilder().WithValue(lower).WithValue(upper).Build();
            var node = new YearFilterTreeNode(string.Empty, column, lower, upper);
            var result = node.CreateChildren();
            Assert.That(result.ElementAt(index).Name, Is.EqualTo(name));
            //TODO: Test value
        }
    }
}
