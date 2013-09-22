using System.Collections.Generic;
using DataExplorer.Domain.FilterTrees;

namespace DataExplorer.Application.FilterTrees
{
    public interface IFilterTreeService
    {
        IEnumerable<FilterTreeNode> GetRoots();
    }
}
