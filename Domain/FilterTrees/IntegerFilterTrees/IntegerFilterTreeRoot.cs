using System.Collections.Generic;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.FilterTrees.NullFilterTrees;
using DataExplorer.Domain.Filters;
using DataExplorer.Domain.Filters.IntegerFilters;

namespace DataExplorer.Domain.FilterTrees.IntegerFilterTrees
{
    public class IntegerFilterTreeRoot : IntegerFilterTreeNode
    {
        public IntegerFilterTreeRoot(string name, Column column)
            : base(name, column, (int) column.Min, (int) column.Max)
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

        public override Filter CreateFilter()
        {
            return _column.HasNulls
                ? new IntegerFilter(_column, _lower, _upper, _column.HasNulls)
                : base.CreateFilter();
        }
    }
}
