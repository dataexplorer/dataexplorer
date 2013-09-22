using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Events;
using DataExplorer.Domain.FilterTrees;

namespace DataExplorer.Application.FilterTrees
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
