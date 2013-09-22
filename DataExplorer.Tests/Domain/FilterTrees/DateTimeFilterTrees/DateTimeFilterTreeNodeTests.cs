using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.FilterTrees;
using DataExplorer.Domain.FilterTrees.DateTimeFilterTrees;
using DataExplorer.Domain.Filters;
using DataExplorer.Tests.Domain.Columns;
using NUnit.Framework;

namespace DataExplorer.Tests.Domain.FilterTrees.DateTimeFilterTrees
{
    [TestFixture]
    public class DateTimeFilterTreeNodeTests
    {
        [Test]
        public void TestCreateFilterShouldCreateDateTimeFilter()
        {
            var column = new ColumnBuilder().Build();
            var root = new FakeDateTimeFilterTreeNode(string.Empty, column, DateTime.MinValue, DateTime.MaxValue);
            var result = (DateTimeFilter) root.CreateFilter();
            Assert.That(result.LowerValue, Is.EqualTo(DateTime.MinValue));
            Assert.That(result.UpperValue, Is.EqualTo(DateTime.MaxValue));
        }
    }

    public class FakeDateTimeFilterTreeNode : DateTimeFilterTreeNode
    {
        public FakeDateTimeFilterTreeNode(string name, Column column, DateTime lowerValue, DateTime upperValue) 
            : base(name, column, lowerValue, upperValue)
        {

        }

        public override IEnumerable<FilterTreeNode> CreateChildren()
        {
            throw new NotImplementedException();
        }
    }
}
