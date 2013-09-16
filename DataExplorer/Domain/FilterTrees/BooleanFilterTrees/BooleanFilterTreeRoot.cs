using System.Collections.Generic;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.FilterTrees.NullFilterTrees;

namespace DataExplorer.Domain.FilterTrees.BooleanFilterTrees
{
    public class BooleanFilterTreeRoot : BooleanFilterTreeNode
    {
        public BooleanFilterTreeRoot(string name, Column column) 
            : base(name, column)
        {
            
        }

        public override IEnumerable<FilterTreeNode> CreateChildren()
        {
            var children = new List<FilterTreeNode>();

            if (_column.HasNulls)
            {
                var nullNode = new NullFilterTreeLeaf("Null", _column);
                children.Add(nullNode);
            }

            var falseNode = new BooleanFilterTreeLeaf("False", _column, false);
            children.Add(falseNode);

            var trueNode = new BooleanFilterTreeLeaf("True", _column, true);
            children.Add(trueNode);

            return children;
        }
    }
}
