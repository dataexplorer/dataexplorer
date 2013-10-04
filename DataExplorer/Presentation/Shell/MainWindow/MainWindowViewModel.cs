using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Presentation.Panes.Layout;
using DataExplorer.Presentation.Panes.Navigation;
using DataExplorer.Presentation.Panes.Viewer;
using DataExplorer.Presentation.Shell.MainMenu;
using DataExplorer.Presentation.Shell.StatusBar;

namespace DataExplorer.Presentation.Shell.MainWindow
{
    public class MainWindowViewModel : IMainWindowViewModel
    {
        private readonly IMainMenuViewModel _mainMenuViewModel;
        private readonly INavigationPaneViewModel _navigationPaneViewModel;
        private readonly IViewerPaneViewModel _viewerPaneViewModel;
        private readonly ILayoutPaneViewModel _layoutPaneViewModel;
        private readonly IStatusBarViewModel _statusBarViewModel;

        public MainWindowViewModel(
            IMainMenuViewModel mainMenuViewModel, 
            INavigationPaneViewModel navigationPaneViewModel,
            IViewerPaneViewModel viewerPaneViewModel,
            ILayoutPaneViewModel layoutPaneViewModel, 
            IStatusBarViewModel statusBarViewModel)
        {
            _mainMenuViewModel = mainMenuViewModel;
            _navigationPaneViewModel = navigationPaneViewModel;
            _viewerPaneViewModel = viewerPaneViewModel;
            _layoutPaneViewModel = layoutPaneViewModel;
            _statusBarViewModel = statusBarViewModel;
        }

        public IMainMenuViewModel MainMenuViewModel
        {
            get { return _mainMenuViewModel; }
        }

        public INavigationPaneViewModel NavigationPaneViewModel
        {
            get { return _navigationPaneViewModel; }
        }

        public IViewerPaneViewModel ViewerPaneViewModel
        {
            get { return _viewerPaneViewModel; }
        }

        public ILayoutPaneViewModel LayoutPaneViewModel
        {
            get { return _layoutPaneViewModel; }
        }

        public IStatusBarViewModel StatusBarViewModel
        {
            get { return _statusBarViewModel; }
        }
    }
}
