using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataExplorer.Presentation.Views.ScatterPlots.Layout
{
    public class ScatterPlotLayoutViewModel : IScatterPlotLayoutViewModel
    {
        private readonly IXAxisLayoutViewModel _xAxisLayoutViewModel;

        public ScatterPlotLayoutViewModel(IXAxisLayoutViewModel xAxisLayoutViewModel)
        {
            _xAxisLayoutViewModel = xAxisLayoutViewModel;
        }

        public IXAxisLayoutViewModel XAxisLayoutViewModel
        {
            get { return _xAxisLayoutViewModel; }
        }
    }
}
