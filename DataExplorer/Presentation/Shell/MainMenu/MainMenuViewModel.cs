using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Presentation.Shell.MainMenu.FileMenu;

namespace DataExplorer.Presentation.Shell.MainMenu
{
    public class MainMenuViewModel : IMainMenuViewModel
    {
        private readonly IFileMenuViewModel _fileMenuViewModel;

        public MainMenuViewModel(IFileMenuViewModel fileMenuViewModel)
        {
            _fileMenuViewModel = fileMenuViewModel;
        }

        public IFileMenuViewModel FileMenuViewModel
        {
            get { return _fileMenuViewModel; }
        }
    }
}
