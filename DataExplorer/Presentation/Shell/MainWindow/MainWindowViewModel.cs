using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Presentation.Panes.Viewer;
using DataExplorer.Presentation.Shell.MainMenu;

namespace DataExplorer.Presentation.Shell.MainWindow
{
    public class MainWindowViewModel : IMainWindowViewModel
    {
        private readonly IMainMenuViewModel _mainMenuViewModel;
        private readonly IViewerPaneViewModel _viewerPaneViewModel;

        public MainWindowViewModel(
            IMainMenuViewModel mainMenuViewModel,
            IViewerPaneViewModel viewerPaneViewModel)
        {
            _mainMenuViewModel = mainMenuViewModel;
            _viewerPaneViewModel = viewerPaneViewModel;
        }

        public IMainMenuViewModel MainMenuViewModel
        {
            get { return _mainMenuViewModel; }
        }

        public IViewerPaneViewModel ViewerPaneViewModel
        {
            get { return _viewerPaneViewModel; }
        }
    }
}
