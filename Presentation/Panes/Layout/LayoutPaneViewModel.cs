using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataExplorer.Presentation.Panes.Layout
{
    public class LayoutPaneViewModel : ILayoutPaneViewModel
    {
        private readonly IScatterPlotLayoutViewModel _scatterPlotLayoutViewModel;

        public LayoutPaneViewModel(IScatterPlotLayoutViewModel scatterPlotLayoutViewModel)
        {
            _scatterPlotLayoutViewModel = scatterPlotLayoutViewModel;
        }

        public IScatterPlotLayoutViewModel ScatterPlotLayoutViewModel
        {
            get { return _scatterPlotLayoutViewModel; }
        }
    }
}
