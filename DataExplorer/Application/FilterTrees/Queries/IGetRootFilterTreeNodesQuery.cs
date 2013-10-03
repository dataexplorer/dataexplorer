using System.Collections.Generic;
using DataExplorer.Domain.FilterTrees;

namespace DataExplorer.Application.FilterTrees.Tasks
{
    public interface IGetRootFilterTreeNodesQuery
    {
        IEnumerable<FilterTreeNode> GetRoots();
    }
}