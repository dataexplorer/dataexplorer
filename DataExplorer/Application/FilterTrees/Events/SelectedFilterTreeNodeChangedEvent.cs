using DataExplorer.Application.Core.Events;
using DataExplorer.Domain.FilterTrees;

namespace DataExplorer.Application.FilterTrees.Events
{
    public class SelectedFilterTreeNodeChangedEvent : IAppEvent
    {
        private readonly FilterTreeNode _node;

        public SelectedFilterTreeNodeChangedEvent(FilterTreeNode node)
        {
            _node = node;
        }

        public FilterTreeNode Node
        {
            get { return _node; }
        }
    }
}
