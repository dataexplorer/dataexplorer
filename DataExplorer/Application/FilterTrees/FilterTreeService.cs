using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Events;
using DataExplorer.Application.FilterTrees.Tasks;
using DataExplorer.Domain.FilterTrees;

namespace DataExplorer.Application.FilterTrees
{
    public class FilterTreeService 
        : IFilterTreeService, 
        IAppHandler<SelectedFilterTreeNodeChangedEvent>
    {
        private readonly IGetRootFilterTreeNodesTask _getRootsTask;
        private readonly IHandleSelectedFilterTreeNodeChangedTask _handleTask;

        public FilterTreeService(
            IGetRootFilterTreeNodesTask getRootsTask, 
            IHandleSelectedFilterTreeNodeChangedTask handleTask)
        {
            _getRootsTask = getRootsTask;
            _handleTask = handleTask;
        }

        public IEnumerable<FilterTreeNode> GetRoots()
        {
            return _getRootsTask.GetRoots();
        }

        public void Handle(SelectedFilterTreeNodeChangedEvent args)
        {
            _handleTask.Handle(args);
        }
    }
}
