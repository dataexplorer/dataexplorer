using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application;
using DataExplorer.Application.Core.Commands;
using DataExplorer.Application.Projects.Commands;
using DataExplorer.Application.Web.Commands;
using DataExplorer.Presentation.Core;
using DataExplorer.Presentation.Core.Commands;
using ICommand = System.Windows.Input.ICommand;

namespace DataExplorer.Presentation.Panes.Navigation.StartMenu
{
    public class StartMenuViewModel : BaseViewModel, IStartMenuViewModel
    {
        private readonly ICommandBus _commandBus;
        private readonly IDialogService _dialogService;

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
            ICommandBus commandBus,
            IDialogService dialogService)
        {
            _commandBus = commandBus;
            _dialogService = dialogService;
            
            _openCommand = new DelegateCommand(Open);
            _importCommand = new DelegateCommand(Import);
            _downloadDataCommand = new DelegateCommand(Download);
        }

        private void Open(object obj)
        {
            _commandBus.Execute(new OpenProjectCommand());
        }

        private void Import(object obj)
        {
            _dialogService.ShowImportDialog();
        }

        private void Download(object obj)
        {
            _commandBus.Execute(new OpenDownloadDataPageCommand());
        }
    }
}
