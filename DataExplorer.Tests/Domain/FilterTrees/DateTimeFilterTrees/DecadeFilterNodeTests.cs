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
    public class DecadeFilterNodeTests
    {
        [Test]
        public void TestCreateChildrenShouldCreateMinYear()
        {
            var lower = DateTime.MinValue;
            var upper = DateTime.MinValue.AddDays(365);
            Test(lower, upper, 0, "1");
        }

        [Test]
        public void TestCreateChildrenShouldCreateMidYear()
        {
            var lower = new DateTime(5555, 1, 1);
            var upper = new DateTime(5556, 1, 1);
            Test(lower, upper, 0, "5555");
        }

        [Test]
        public void TestCreateChildrenShouldCreateMaxYear()
        {
            var lower = DateTime.MaxValue.AddDays(-365);
            var upper = DateTime.MaxValue;
            Test(lower, upper, 1, "9999");
        }

        private void Test(DateTime lower, DateTime upper, int index, string name)
        {
            var column = new ColumnBuilder().WithValue(lower).WithValue(upper).Build();
            var node = new DecadeFilterTreeNode(string.Empty, column, lower, upper);
            var result = node.CreateChildren();
            Assert.That(result.ElementAt(index).Name, Is.EqualTo(name));
            //TODO: Test value
        }
    }
}
