using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Core.Events;
using DataExplorer.Application.FilterTrees;
using DataExplorer.Application.FilterTrees.Events;
using DataExplorer.Domain.FilterTrees;
using DataExplorer.Presentation.Core;

namespace DataExplorer.Presentation.Panes.Navigation.NavigationTree
{
    public class TreeNodeViewModel : BaseViewModel
    {
        private readonly FilterTreeNode _filterTreeNode;
        private readonly IFilterTreeService _service;
        private bool _isSelected;

        public TreeNodeViewModel(
            FilterTreeNode filterTreeNode, 
            IFilterTreeService service)
        {
            _filterTreeNode = filterTreeNode;
            _service = service;
        }

        public string Name
        {
            get { return _filterTreeNode.Name; }
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
                AppEvents.Raise(new SelectedFilterTreeNodeChangedEvent(_filterTreeNode));
        }

        private IEnumerable<TreeNodeViewModel> GetChildren()
        {
            var filterTreeNodes = _filterTreeNode.CreateChildren();

            var viewModels = filterTreeNodes
                .Select(p => new TreeNodeViewModel(p, _service));

            return viewModels;
        }
    }
}
