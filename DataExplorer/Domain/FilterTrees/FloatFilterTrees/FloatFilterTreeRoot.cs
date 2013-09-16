using System.Collections.Generic;
using DataExplorer.Domain.Columns;

namespace DataExplorer.Domain.FilterTrees.FloatFilterTrees
{
    public class FloatFilterTreeRoot : FloatFilterTreeNode
    {
        public FloatFilterTreeRoot(string name, Column column) : base(name, column)
        {
        }

        public override IEnumerable<FilterTreeNode> CreateChildren()
        {
            throw new System.NotImplementedException();
        }
    }
}
