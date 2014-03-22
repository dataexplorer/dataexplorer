using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Core.Messages;
using DataExplorer.Application.FilterTrees.Commands;
using DataExplorer.Domain.FilterTrees;
using DataExplorer.Presentation.Core;

namespace DataExplorer.Presentation.Panes.Navigation.NavigationTree
{
    public class TreeNodeViewModel : BaseViewModel
    {
        private readonly FilterTreeNode _filterTreeNode;
        private readonly IMessageBus _messageBus;
        private bool _isSelected;

        public TreeNodeViewModel(
            FilterTreeNode filterTreeNode,
            IMessageBus messageBus)
        {
            _filterTreeNode = filterTreeNode;
            _messageBus = messageBus;
        }

        public string Name
        {
            get { return _filterTreeNode.Name; }
        }

        public Domain.Filters.Filter Filter
        {
            get { return _filterTreeNode.CreateFilter(); }
        }

        public IEnumerable<TreeNodeViewModel> Children
        {
            get { return GetChildren(); }
        }

        public bool IsSelected
        {
            get { return _isSelected; }
            set { SetIsSelected(value); }
        }

        private void SetIsSelected(bool value)
        {
            _isSelected = value;
            
            OnPropertyChanged(() => IsSelected);

            if (_isSelected)
                _messageBus.Execute(new SelectFilterTreeNodeCommand(_filterTreeNode));
        }

        private IEnumerable<TreeNodeViewModel> GetChildren()
        {
            var filterTreeNodes = _filterTreeNode.CreateChildren();

            var viewModels = filterTreeNodes
                .Select(p => new TreeNodeViewModel(p, _messageBus));

            return viewModels;
        }
    }
}
