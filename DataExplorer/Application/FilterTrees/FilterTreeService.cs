using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Core.Events;
using DataExplorer.Application.FilterTrees.Tasks;
using DataExplorer.Domain.FilterTrees;

namespace DataExplorer.Application.FilterTrees
{
    public class FilterTreeService 
        : IFilterTreeService, 
        IAppHandler<SelectedFilterTreeNodeChangedEvent>
    {
        private readonly IGetRootFilterTreeNodesQuery _getRootsQuery;
        private readonly ISelectedFilterTreeNodeChangedEventHandler _eventHandler;

        public FilterTreeService(
            IGetRootFilterTreeNodesQuery getRootsQuery, 
            ISelectedFilterTreeNodeChangedEventHandler eventHandler)
        {
            _getRootsQuery = getRootsQuery;
            _eventHandler = eventHandler;
        }

        public IEnumerable<FilterTreeNode> GetRoots()
        {
            return _getRootsQuery.GetRoots();
        }

        public void Handle(SelectedFilterTreeNodeChangedEvent args)
        {
            _eventHandler.Handle(args);
        }
    }
}
