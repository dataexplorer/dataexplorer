using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Columns;

namespace DataExplorer.Domain.FilterTrees.FloatFilterTrees
{
    public abstract class FloatFilterTreeNode : FilterTreeNode
    {
        protected FloatFilterTreeNode(string name, Column column)
            : base(name, column)
        {
        }
    }
}
