using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Presentation.Views.ScatterPlots.Layout;

namespace DataExplorer.Presentation.Panes.Layout
{
    public interface ILayoutPaneViewModel
    {
        IScatterPlotLayoutViewModel ScatterPlotLayoutViewModel { get; }
    }
}
