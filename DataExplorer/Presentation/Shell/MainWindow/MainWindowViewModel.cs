using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Presentation.Panes.Viewer;

namespace DataExplorer.Presentation.Shell.MainWindow
{
    public class MainWindowViewModel : IMainWindowViewModel
    {
        private readonly IViewerPaneViewModel _viewerPaneViewModel;

        public MainWindowViewModel(IViewerPaneViewModel viewerPaneViewModel)
        {
            _viewerPaneViewModel = viewerPaneViewModel;
        }

        public IViewerPaneViewModel ViewerPaneViewModel
        {
            get { return _viewerPaneViewModel; }
        }
    }
}
