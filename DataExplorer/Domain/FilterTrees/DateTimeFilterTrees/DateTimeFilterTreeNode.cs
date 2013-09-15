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
        protected DateTimeFilterTreeNode(string name, Column column)
            : base(name, column)
        {
        }
    }
}
