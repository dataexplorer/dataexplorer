using System;
using System.Collections.Generic;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.FilterTrees.BooleanFilterTrees;
using DataExplorer.Domain.FilterTrees.DateTimeFilterTrees;
using DataExplorer.Domain.FilterTrees.FloatFilterTrees;
using DataExplorer.Domain.FilterTrees.IntegerFilterTrees;
using DataExplorer.Domain.FilterTrees.StringFilterTrees;

namespace DataExplorer.Domain.FilterTrees
{
    public class FilterTreeFactory : IFilterTreeNodeFactory
    {
        public FilterTreeNode CreateRoot(Column column)
        {
            if (column.Type == typeof(Boolean))
                return new BooleanFilterTreeRoot(column.Name, column);

            if (column.Type == typeof(DateTime))
                return new DateTimeFilterTreeRoot(column.Name, column);

            if (column.Type == typeof(Double))
                return new FloatFilterTreeRoot(column.Name, column);

            if (column.Type == typeof(Int32))
                return new IntegerFilterTreeRoot(column.Name, column);

            if (column.Type == typeof(String))
                return new StringFilterTreeRoot(column.Name, column);

            throw new ArgumentException("Column data type is not recognized.");
        }
    }
}
