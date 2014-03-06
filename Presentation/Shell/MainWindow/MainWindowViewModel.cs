using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Application;
using DataExplorer.Application.Application.Queries;
using DataExplorer.Application.Core.Queries;
using DataExplorer.Presentation.Panes.Filter;
using DataExplorer.Presentation.Panes.Layout;
using DataExplorer.Presentation.Panes.Legend;
using DataExplorer.Presentation.Panes.Navigation;
using DataExplorer.Presentation.Panes.Property;
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
        private readonly IFilterPaneViewModel _filterPaneViewModel;
        private readonly ILayoutPaneViewModel _layoutPaneViewModel;
        private readonly ILegendPaneViewModel _legendPaneViewModel;
        private readonly IPropertyPaneViewModel _propertyPaneViewModel;
        private readonly IStatusBarViewModel _statusBarViewModel;

        public MainWindowViewModel(
            IMainMenuViewModel mainMenuViewModel, 
            INavigationPaneViewModel navigationPaneViewModel,
            IViewerPaneViewModel viewerPaneViewModel,
            IFilterPaneViewModel filterPaneViewModel,
            ILayoutPaneViewModel layoutPaneViewModel,
            ILegendPaneViewModel legendPaneViewModel,
            IPropertyPaneViewModel propertyPaneViewModel,
            IStatusBarViewModel statusBarViewModel)
        {
            _mainMenuViewModel = mainMenuViewModel;
            _navigationPaneViewModel = navigationPaneViewModel;
            _viewerPaneViewModel = viewerPaneViewModel;
            _filterPaneViewModel = filterPaneViewModel;
            _layoutPaneViewModel = layoutPaneViewModel;
            _legendPaneViewModel = legendPaneViewModel;
            _propertyPaneViewModel = propertyPaneViewModel;
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

        public IFilterPaneViewModel FilterPaneViewModel
        {
            get { return _filterPaneViewModel; }
        }

        public ILayoutPaneViewModel LayoutPaneViewModel
        {
            get { return _layoutPaneViewModel; }
        }

        public ILegendPaneViewModel LegendPaneViewModel
        {
             get { return _legendPaneViewModel; }
        }

        public IPropertyPaneViewModel PropertyPaneViewModel
        {
            get { return _propertyPaneViewModel; }
        }

        public IStatusBarViewModel StatusBarViewModel
        {
            get { return _statusBarViewModel; }
        }
    }
}
