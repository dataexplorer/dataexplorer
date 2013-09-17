using System.Collections.Generic;
using DataExplorer.Domain.Columns;

namespace DataExplorer.Domain.FilterTrees.IntegerFilterTrees
{
    public class IntegerFilterTreeRoot : IntegerFilterTreeNode
    {
        public IntegerFilterTreeRoot(string name, Column column)
            : base(name, column)
        {
        }

        public override IEnumerable<FilterTreeNode> CreateChildren()
        {
            return new List<FilterTreeNode>();
            throw new System.NotImplementedException();
        }
    }
}
