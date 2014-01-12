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
        private readonly IYAxisLayoutViewModel _yAxisLayoutViewModel;

        public ScatterPlotLayoutViewModel(
            IXAxisLayoutViewModel xAxisLayoutViewModel,
            IYAxisLayoutViewModel yAxisLayoutViewModel)
        {
            _xAxisLayoutViewModel = xAxisLayoutViewModel;
            _yAxisLayoutViewModel = yAxisLayoutViewModel;
        }

        public IXAxisLayoutViewModel XAxisLayoutViewModel
        {
            get { return _xAxisLayoutViewModel; }
        }

        public IYAxisLayoutViewModel YAxisLayoutViewModel
        {
            get { return _yAxisLayoutViewModel; }
        }
    }
}
