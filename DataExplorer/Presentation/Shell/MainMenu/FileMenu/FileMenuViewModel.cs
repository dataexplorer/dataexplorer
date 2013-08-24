using System.Windows.Input;
using DataExplorer.Application;
using DataExplorer.Application.Application;
using DataExplorer.Application.Projects;
using DataExplorer.Presentation.Core;
using DataExplorer.Presentation.Dialogs;

namespace DataExplorer.Presentation.Shell.MainMenu.FileMenu
{
    public class FileMenuViewModel : IFileMenuViewModel
    {
        private readonly IApplicationService _applicationService;
        private readonly IProjectService _projectService;
        private readonly IDialogService _dialogService;

        private readonly ICommand _openCommand;
        private readonly ICommand _closeCommand;
        private readonly ICommand _importCommand;
        private readonly ICommand _exitCommand;

        public FileMenuViewModel(
            IApplicationService applicationService,
            IProjectService projectService,
            IDialogService dialogService)
        {
            _applicationService = applicationService;
            _projectService = projectService;
            _dialogService = dialogService;

            _exitCommand = new DelegateCommand(Exit);
            _closeCommand = new DelegateCommand(Close);
            _importCommand = new DelegateCommand(Import);
            _openCommand = new DelegateCommand(Open);
        }

        public ICommand CloseCommand
        {
            get { return _closeCommand; }
        }

        public ICommand ImportCommand
        {
            get { return _importCommand; }
        }

        public ICommand OpenCommand
        {
            get { return _openCommand; }
        }

        public ICommand ExitCommand
        {
            get { return _exitCommand; }
        }

        private void Open(object parameter)
        {
            _projectService.OpenProject();
        }

        private void Close(object parameter)
        {
            _projectService.CloseProject();
        }

        private void Import(object parameter)
        {
            _dialogService.ShowImportDialog();
        }

        private void Exit(object parameter)
        {
            _applicationService.Exit();
        }
    }
}