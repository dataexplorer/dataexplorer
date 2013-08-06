using System.Windows.Input;
using DataExplorer.Application;
using DataExplorer.Application.Application;
using DataExplorer.Presentation.Core;

namespace DataExplorer.Presentation.Shell.MainMenu.FileMenu
{
    public class FileMenuViewModel : IFileMenuViewModel
    {
        private readonly IApplicationService _applicationService;

        private readonly ICommand _exitCommand;

        public FileMenuViewModel(IApplicationService applicationService)
        {
            _applicationService = applicationService;

            _exitCommand = new DelegateCommand(Exit);
        }
        
        public ICommand ExitCommand
        {
            get { return _exitCommand; }
        }

        private void Exit(object obj)
        {
            _applicationService.Exit();
        }
    }
}