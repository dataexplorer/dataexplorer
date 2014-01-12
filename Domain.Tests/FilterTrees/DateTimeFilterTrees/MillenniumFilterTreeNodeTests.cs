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
            Test(lower, upper, 0, "000s");
        }

        [Test]
        public void TestCreateChildrenShouldCreateMidCentury()
        {
            var lower = new DateTime(5500, 1, 1);
            var upper = new DateTime(5600, 1, 1);
            Test(lower, upper, 0, "5500s");
        }

        [Test]
        public void TestCreateChildrenShouldCreateMaxCentury()
        {
            var lower = DateTime.MaxValue.AddDays(-36524);
            var upper = DateTime.MaxValue;
            Test(lower, upper, 1, "9900s");
        }

        private void Test(DateTime lower, DateTime upper, int index, string name)
        {
            var column = new ColumnBuilder().WithValue(lower).WithValue(upper).Build();
            var node = new MillenniumFilterTreeNode(string.Empty, column, lower, upper);
            var result = node.CreateChildren();
            Assert.That(result.ElementAt(index).Name, Is.EqualTo(name));
            //TODO: Test value
        }
    }
}
