using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DataExplorer.Application.Projects;
using DataExplorer.Application.Web;
using DataExplorer.Presentation.Core;
using DataExplorer.Presentation.Core.Commands;
using DataExplorer.Presentation.Dialogs;

namespace DataExplorer.Presentation.Panes.Navigation.StartMenu
{
    public class StartMenuViewModel : BaseViewModel, IStartMenuViewModel
    {
        private readonly IProjectService _projectService;
        private readonly IDialogService _dialogService;
        private readonly IWebService _webService;

        private readonly DelegateCommand _openCommand;
        private readonly DelegateCommand _importCommand;
        private readonly DelegateCommand _downloadDataCommand;

        public ICommand OpenCommand
        {
            get { return _openCommand; }
        }

        public ICommand ImportCommand
        {
            get { return _importCommand; }
        }

        public ICommand DownloadDataCommand
        {
            get { return _downloadDataCommand; }
        }

        public StartMenuViewModel(
            IProjectService projectService,
            IDialogService dialogService,
            IWebService webService)
        {
            _projectService = projectService;
            _dialogService = dialogService;
            _webService = webService;

            _openCommand = new DelegateCommand(Open);
            _importCommand = new DelegateCommand(Import);
            _downloadDataCommand = new DelegateCommand(Download);
        }

        private void Open(object obj)
        {
            _projectService.OpenProject();
        }

        private void Import(object obj)
        {
            _dialogService.ShowImportDialog();
        }

        private void Download(object obj)
        {
            _webService.LaunchDownloadDataPage();
        }
    }
}
