using System;
using DataExplorer.Domain.Columns;

namespace DataExplorer.Domain.FilterTrees.BooleanFilterTrees
{
    public class BooleanFilterTreeFactory : IBooleanFilterTreeFactory
    {
        public FilterTreeNode CreateRoot(Column column)
        {
            return new BooleanFilterTreeRoot(column.Name);
        }
    }
}
