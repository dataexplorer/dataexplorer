using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Columns;

namespace DataExplorer.Domain.FilterTrees.BooleanFilterTrees
{
    public abstract class BooleanFilterTreeNode : FilterTreeNode
    {
        protected BooleanFilterTreeNode(string name, Column column)
            : base(name, column)
        {
        }
    }
}
