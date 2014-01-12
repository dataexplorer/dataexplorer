using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Columns;

namespace DataExplorer.Domain.FilterTrees.FloatFilterTrees
{
    public class FloatFilterTreeLeaf : FloatFilterTreeNode
    {
        public FloatFilterTreeLeaf(string name, Column column, double value)
            : base(name, column, value, value)
        {
        }

        public override IEnumerable<FilterTreeNode> CreateChildren()
        {
            return new List<FilterTreeNode>();
        }
    }
}
