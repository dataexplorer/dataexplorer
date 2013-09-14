using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Presentation.Panes.Layout;
using DataExplorer.Presentation.Panes.Navigation;
using DataExplorer.Presentation.Panes.Viewer;
using DataExplorer.Presentation.Shell.MainMenu;

namespace DataExplorer.Presentation.Shell.MainWindow
{
    public class MainWindowViewModel : IMainWindowViewModel
    {
        private readonly IMainMenuViewModel _mainMenuViewModel;
        private readonly INavigationPaneViewModel _navigationPaneViewModel;
        private readonly IViewerPaneViewModel _viewerPaneViewModel;
        private readonly ILayoutPaneViewModel _layoutPaneViewModel;

        public MainWindowViewModel(
            IMainMenuViewModel mainMenuViewModel, 
            INavigationPaneViewModel navigationPaneViewModel,
            IViewerPaneViewModel viewerPaneViewModel,
            ILayoutPaneViewModel layoutPaneViewModel)
        {
            _mainMenuViewModel = mainMenuViewModel;
            _navigationPaneViewModel = navigationPaneViewModel;
            _viewerPaneViewModel = viewerPaneViewModel;
            _layoutPaneViewModel = layoutPaneViewModel;
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
    }
}
