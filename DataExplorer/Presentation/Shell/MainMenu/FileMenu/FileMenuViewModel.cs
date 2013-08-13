using System.Windows.Input;
using DataExplorer.Application;
using DataExplorer.Application.Application;
using DataExplorer.Application.Project;
using DataExplorer.Presentation.Core;

namespace DataExplorer.Presentation.Shell.MainMenu.FileMenu
{
    public class FileMenuViewModel : IFileMenuViewModel
    {
        private readonly IApplicationService _applicationService;
        private readonly IProjectService _projectService;

        private readonly ICommand _exitCommand;
        private readonly ICommand _openCommand;

        public FileMenuViewModel(
            IApplicationService applicationService,
            IProjectService projectService)
        {
            _applicationService = applicationService;
            _projectService = projectService;

            _exitCommand = new DelegateCommand(Exit);
            _openCommand = new DelegateCommand(Open);
        }
        
        public ICommand ExitCommand
        {
            get { return _exitCommand; }
        }

        public ICommand OpenCommand
        {
            get { return _openCommand; }
        }

        private void Exit(object parameter)
        {
            _applicationService.Exit();
        }

        private void Open(object parameter)
        {
            _projectService.OpenProject();
        }
    }
}