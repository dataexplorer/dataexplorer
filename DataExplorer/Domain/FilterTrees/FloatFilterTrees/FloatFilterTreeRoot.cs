using System.Collections.Generic;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.FilterTrees.NullFilterTrees;

namespace DataExplorer.Domain.FilterTrees.FloatFilterTrees
{
    public class FloatFilterTreeRoot : FloatFilterTreeNode
    {
        public FloatFilterTreeRoot(string name, Column column) 
            : base(name, column, (double) column.Min, (double) column.Max)
        {
        }

        public override IEnumerable<FilterTreeNode> CreateChildren()
        {
            if (_column.HasNulls)
                yield return  new NullFilterTreeLeaf("(Null)", _column);

            var derivedChildren = base.CreateChildren();

            foreach (var child in derivedChildren)
                yield return child;
        }
    }
}
