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
    public class CenturyFilterTreeNodeTests
    {
        [Test]
        public void TestCreateChildrenShouldCreateMinDecade()
        {
            var lower = DateTime.MinValue;
            var upper = DateTime.MinValue.AddDays(3652);
            Test(lower, upper, 0, "00s");
        }

        [Test]
        public void TestCreateChildrenShouldCreateMidDecade()
        {
            var lower = new DateTime(5550, 1, 1);
            var upper = new DateTime(5560, 1, 1);
            Test(lower, upper, 0, "5550s");
        }

        [Test]
        public void TestCreateChildrenShouldCreateMaxDecade()
        {
            var lower = DateTime.MaxValue.AddDays(-3652);
            var upper = DateTime.MaxValue;
            Test(lower, upper, 1, "9990s");
        }


        private void Test(DateTime lower, DateTime upper, int index, string name)
        {
            var column = new ColumnBuilder().WithValue(lower).WithValue(upper).Build();
            var node = new CenturyFilterTreeNode(string.Empty, column, lower, upper);
            var result = node.CreateChildren();
            Assert.That(result.ElementAt(index).Name, Is.EqualTo(name));
            //TODO: Test value
        }
    }
}
