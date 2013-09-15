using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Columns;

namespace DataExplorer.Domain.FilterTrees.NullFilterTrees
{
    public class NullFilterTreeLeaf : FilterTreeNode
    {
        public NullFilterTreeLeaf(string name, Column column) 
            : base(name, column)
        {
        }
    }
}
