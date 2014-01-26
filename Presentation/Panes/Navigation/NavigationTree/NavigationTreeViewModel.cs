using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Core.Events;
using DataExplorer.Application.Core.Messages;
using DataExplorer.Application.FilterTrees.Queries;
using DataExplorer.Application.Importers.CsvFiles.Events;
using DataExplorer.Application.Projects.Events;
using DataExplorer.Presentation.Core;

namespace DataExplorer.Presentation.Panes.Navigation.NavigationTree
{
    public class NavigationTreeViewModel 
        : BaseViewModel, 
        INavigationTreeViewModel,
        IEventHandler<ProjectOpeningEvent>,
        IEventHandler<ProjectOpenedEvent>,
        IEventHandler<ProjectClosedEvent>,
        IEventHandler<CsvFileImportingEvent>,
        IEventHandler<CsvFileImportedEvent>
    {
        private readonly IMessageBus _messageBus;

        private List<TreeNodeViewModel> _treeNodeViewModels;

        public List<TreeNodeViewModel> TreeNodeViewModels
        {
            get { return _treeNodeViewModels; }
        }

        public NavigationTreeViewModel(IMessageBus messageBus)
        {
            _messageBus = messageBus;
            _treeNodeViewModels = new List<TreeNodeViewModel>();
        }

        public void Handle(ProjectOpeningEvent args)
        {
            ClearViewModels();
        }

        public void Handle(ProjectOpenedEvent args)
        {
            RefreshViewModels();
        }

        public void Handle(ProjectClosedEvent args)
        {
            RefreshViewModels();
        }

        public void Handle(CsvFileImportingEvent args)
        {
            ClearViewModels();
        }

        public void Handle(CsvFileImportedEvent args)
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
            var filterTreeNodes = _messageBus.Execute(new GetRootFilterTreeNodesQuery());

            _treeNodeViewModels = filterTreeNodes
                .Select(p => new TreeNodeViewModel(p, _messageBus))
                .ToList();

            OnPropertyChanged(() => TreeNodeViewModels);
        }
    }
}
