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
            var children = new List<FilterTreeNode>();

            if (_column.HasNulls)
            {
                var nullLeaf = new NullFilterTreeLeaf("(Null)", _column);
                children.Add(nullLeaf);
            }
                
            var derivedChildren = base.CreateChildren();
            children.AddRange(derivedChildren);

            return children;
        }
    }
}
