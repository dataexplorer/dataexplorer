using System;
using System.Collections.Generic;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.FilterTrees.NullFilterTrees;

namespace DataExplorer.Domain.FilterTrees.BooleanFilterTrees
{
    public class BooleanFilterTreeFactory : IBooleanFilterTreeFactory
    {
        public FilterTreeNode CreateRoot(Column column)
        {
            return new BooleanFilterTreeRoot(column.Name, column);
        }

        public IEnumerable<FilterTreeNode> CreateChildren(BooleanFilterTreeNode node)
        {
            if (node is BooleanFilterTreeRoot)
                return CreateChildrenOfRoot((BooleanFilterTreeRoot) node);
            
            return new List<FilterTreeNode>();
        }

        private IEnumerable<FilterTreeNode> CreateChildrenOfRoot(BooleanFilterTreeRoot root)
        {
            var children = new List<FilterTreeNode>();

            if (root.Column.HasNulls)
            {
                var nullNode = new NullFilterTreeLeaf("Null", root.Column);
                children.Add(nullNode);
            }

            var falseNode = new BooleanFilterTreeLeaf("False", root.Column, false);
            children.Add(falseNode);

            var trueNode = new BooleanFilterTreeLeaf("True", root.Column, true);
            children.Add(trueNode);

            return children;
        }
    }
}
