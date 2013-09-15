using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.FilterTrees;
using DataExplorer.Domain.FilterTrees;
using DataExplorer.Presentation.Core;

namespace DataExplorer.Presentation.Panes.Navigation.NavigationTree
{
    public class TreeNodeViewModel : BaseViewModel
    {
        private readonly FilterTreeNode _filterTreeNode;
        private readonly IFilterTreeService _service;

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
            get
            {
                return new List<TreeNodeViewModel>();

                var filterTreeNodes = _service.GetChildren(_filterTreeNode);

                var viewModels = filterTreeNodes
                    .Select(p => new TreeNodeViewModel(p, _service));

                return viewModels;
            }
        }
    }
}
