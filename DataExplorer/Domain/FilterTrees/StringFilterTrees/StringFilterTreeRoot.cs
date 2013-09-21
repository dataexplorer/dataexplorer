using System.Collections.Generic;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.FilterTrees.NullFilterTrees;

namespace DataExplorer.Domain.FilterTrees.StringFilterTrees
{
    public class StringFilterTreeRoot : StringFilterTreeNode
    {
        public StringFilterTreeRoot(string name, Column column) 
            : base(name, column, string.Empty, 0)
        {
        }

        public override IEnumerable<FilterTreeNode> CreateChildren()
        {
            if (_column.HasNulls)
                yield return new NullFilterTreeLeaf("(Null)", _column);

            var derivedChildren = base.CreateChildren();

            foreach (var child in derivedChildren)
                yield return child;
        }
    }
}
