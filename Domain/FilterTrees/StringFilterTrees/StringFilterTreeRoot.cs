using System.Collections.Generic;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.FilterTrees.NullFilterTrees;
using DataExplorer.Domain.Filters;
using DataExplorer.Domain.Filters.StringFilters;

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

            // TODO: Uncomment this line (and unit test) once I have added string equality filters to leaf nodes
            //if (_column.Values.Contains(string.Empty))
            //    yield return new StringFilterTreeLeaf("(Empty)", _column, string.Empty, 1);

            var derivedChildren = base.CreateChildren();

            foreach (var child in derivedChildren)
                yield return child;
        }

        public override Filter CreateFilter()
        {
            return _column.HasNulls 
                ? new StringFilter(_column, _value, _column.HasNulls)
                : base.CreateFilter();
        }
    }
}
