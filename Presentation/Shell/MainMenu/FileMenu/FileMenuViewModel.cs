using DataExplorer.Application;
using DataExplorer.Application.Application;
using DataExplorer.Application.Application.Commands;
using DataExplorer.Application.Core.Commands;
using DataExplorer.Application.Projects;
using DataExplorer.Presentation.Core.Commands;
using ICommand = System.Windows.Input.ICommand;

namespace DataExplorer.Presentation.Shell.MainMenu.FileMenu
{
    public class FileMenuViewModel : IFileMenuViewModel
    {
        private readonly ICommandBus _commandBus;
        private readonly IProjectService _projectService;
        private readonly IDialogService _dialogService;

        private readonly ICommand _openCommand;
        private readonly ICommand _saveCommand;
        private readonly ICommand _closeCommand;
        private readonly ICommand _importCommand;
        private readonly ICommand _exitCommand;

        public FileMenuViewModel(
            ICommandBus commandBus,
            IProjectService projectService,
            IDialogService dialogService)
        {
            _commandBus = commandBus;
            _projectService = projectService;
            _dialogService = dialogService;

            _openCommand = new DelegateCommand(Open);
            _saveCommand = new DelegateCommand(Save);
            _closeCommand = new DelegateCommand(Close);
            _importCommand = new DelegateCommand(Import);
            _exitCommand = new DelegateCommand(Exit);
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

        public ICommand SaveCommand
        {
            get { return _saveCommand; }
        }

        public ICommand ExitCommand
        {
            get { return _exitCommand; }
        }

        private void Open(object parameter)
        {
            _projectService.OpenProject();
        }

        private void Save(object obj)
        {
            _projectService.SaveProject();
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
            _commandBus.Execute(new ExitCommand());
        }
    }
}