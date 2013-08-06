using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Presentation.Views.ScatterPlot;

namespace DataExplorer.Presentation.Panes.Viewer
{
    public interface IViewerPaneViewModel
    {
        IScatterPlotViewModel ScatterPlotViewModel { get; }
    }
}
