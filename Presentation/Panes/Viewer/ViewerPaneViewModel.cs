using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Presentation.Views.ScatterPlots;

namespace DataExplorer.Presentation.Panes.Viewer
{
    public class ViewerPaneViewModel : IViewerPaneViewModel
    {
        private readonly IScatterPlotViewModel _scatterPlotViewModel;

        public ViewerPaneViewModel(IScatterPlotViewModel scatterPlotViewModel)
        {
            _scatterPlotViewModel = scatterPlotViewModel;
        }

        public IScatterPlotViewModel ScatterPlotViewModel
        {
            get { return _scatterPlotViewModel; }
        }
    }
}
