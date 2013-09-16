using System.Collections.Generic;
using DataExplorer.Domain.Columns;

namespace DataExplorer.Domain.FilterTrees
{
    public interface IFilterTreeNodeFactory
    {
        FilterTreeNode CreateRoot(Column column);
    }
}
