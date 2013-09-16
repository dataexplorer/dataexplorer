using System;
using System.Collections.Generic;
using DataExplorer.Domain.Columns;

namespace DataExplorer.Domain.FilterTrees.DateTimeFilterTrees
{
    public class SecondFilterTreeNode : DateTimeFilterTreeNode
    {
        public SecondFilterTreeNode(string name, Column column, DateTime lower, DateTime upper)
            : base(name, column, lower, upper)
        {
        }

        public override IEnumerable<FilterTreeNode> CreateChildren()
        {
            return new List<FilterTreeNode>();
        }
    }
}
