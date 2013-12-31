using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Core.Events;
using DataExplorer.Application.FilterTrees;
using DataExplorer.Application.Importers.CsvFiles.Events;
using DataExplorer.Application.Projects.Events;
using DataExplorer.Presentation.Core;

namespace DataExplorer.Presentation.Panes.Navigation.NavigationTree
{
    public class NavigationTreeViewModel 
        : BaseViewModel, 
        INavigationTreeViewModel,
        IEventHandler<CsvFileImportingEvent>,
        IEventHandler<CsvFileImportedEvent>,
        IEventHandler<ProjectOpeningEvent>,
        IEventHandler<ProjectOpenedEvent>
    {
        private readonly IFilterTreeService _service;

        private List<TreeNodeViewModel> _treeNodeViewModels;

        public List<TreeNodeViewModel> TreeNodeViewModels
        {
            get { return _treeNodeViewModels; }
        }

        public NavigationTreeViewModel(IFilterTreeService service)
        {
            _service = service;
            _treeNodeViewModels = new List<TreeNodeViewModel>();
        }

        public void Handle(CsvFileImportingEvent args)
        {
            ClearViewModels();
        }

        public void Handle(CsvFileImportedEvent args)
        {
            RefreshViewModels();
        }

        public void Handle(ProjectOpeningEvent args)
        {
            ClearViewModels();
        }

        public void Handle(ProjectOpenedEvent args)
        {
            RefreshViewModels();
        }

        private void ClearViewModels()
        {
            _treeNodeViewModels.Clear();

            OnPropertyChanged(() => TreeNodeViewModels);
        }

        private void RefreshViewModels()
        {
            var filterTreeNodes = _service.GetRoots();

            _treeNodeViewModels = filterTreeNodes
                .Select(p => new TreeNodeViewModel(p, _service))
                .ToList();

            OnPropertyChanged(() => TreeNodeViewModels);
        }
    }
}
