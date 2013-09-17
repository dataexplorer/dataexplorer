using System.Collections.Generic;
using DataExplorer.Domain.Columns;

namespace DataExplorer.Domain.FilterTrees.StringFilterTrees
{
    public class StringFilterTreeRoot : StringFilterTreeNode
    {
        public StringFilterTreeRoot(string name, Column column) 
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
