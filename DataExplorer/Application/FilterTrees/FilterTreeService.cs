using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Core.Events;
using DataExplorer.Application.FilterTrees.Commands;
using DataExplorer.Application.FilterTrees.Queries;
using DataExplorer.Domain.FilterTrees;

namespace DataExplorer.Application.FilterTrees
{
    public class FilterTreeService 
        : IFilterTreeService
    {
        private readonly IGetRootFilterTreeNodesQuery _getRootsQuery;
        private readonly ISelectFilterTreeNodeCommand _selectCommand;

        public FilterTreeService(
            IGetRootFilterTreeNodesQuery getRootsQuery, 
            ISelectFilterTreeNodeCommand selectCommand)
        {
            _getRootsQuery = getRootsQuery;
            _selectCommand = selectCommand;
        }

        public IEnumerable<FilterTreeNode> GetRoots()
        {
            return _getRootsQuery.GetRoots();
        }

        public void SelectFilterTreeNode(FilterTreeNode filterTreeNode)
        {
            _selectCommand.Execute(filterTreeNode);
        }
    }
}
