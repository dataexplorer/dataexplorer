using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Columns;

namespace DataExplorer.Domain.FilterTrees.DateTimeFilterTrees
{
    public abstract class DateTimeFilterTreeNode : FilterTreeNode
    {
        protected readonly DateTime _lower;
        protected readonly DateTime _upper;

        protected DateTimeFilterTreeNode(string name, Column column, DateTime lower, DateTime upper)
            : base(name, column)
        {
            _lower = lower;
            _upper = upper;
        }
    }
}
