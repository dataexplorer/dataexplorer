using System;
using System.Collections.Generic;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Filters;
using DataExplorer.Domain.FilterTrees;
using DataExplorer.Domain.FilterTrees.DateTimeFilterTrees;
using DataExplorer.Domain.Tests.Columns;
using NUnit.Framework;

namespace DataExplorer.Domain.Tests.FilterTrees.DateTimeFilterTrees
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
