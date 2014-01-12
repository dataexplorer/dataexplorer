using System.Collections.Generic;
using DataExplorer.Domain.FilterTrees;

namespace DataExplorer.Application.FilterTrees.Queries
{
    public interface IGetRootFilterTreeNodesQuery
    {
        IEnumerable<FilterTreeNode> GetRoots();
    }
}