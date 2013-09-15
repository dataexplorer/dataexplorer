using System.Collections.Generic;
using DataExplorer.Domain.FilterTrees;
using DataExplorer.Presentation.Panes.Navigation.NavigationTree;

namespace DataExplorer.Application.FilterTrees
{
    public interface IFilterTreeService
    {
        List<FilterTreeNode> GetRoots();

        IEnumerable<FilterTreeNode> GetChildren(FilterTreeNode filterTreeNode);
    }
}
