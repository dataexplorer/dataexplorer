using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Presentation.Views.ScatterPlots.Layout.Color;
using DataExplorer.Presentation.Views.ScatterPlots.Layout.XAxis;
using DataExplorer.Presentation.Views.ScatterPlots.Layout.YAxis;

namespace DataExplorer.Presentation.Views.ScatterPlots.Layout
{
    public class ScatterPlotLayoutViewModel : IScatterPlotLayoutViewModel
    {
        private readonly IXAxisLayoutViewModel _xAxisLayoutViewModel;
        private readonly IYAxisLayoutViewModel _yAxisLayoutViewModel;
        private readonly IColorLayoutViewModel _colorLayoutViewModel;

        public ScatterPlotLayoutViewModel(
            IXAxisLayoutViewModel xAxisLayoutViewModel, 
            IYAxisLayoutViewModel yAxisLayoutViewModel, 
            IColorLayoutViewModel colorLayoutViewModel)
        {
            _xAxisLayoutViewModel = xAxisLayoutViewModel;
            _yAxisLayoutViewModel = yAxisLayoutViewModel;
            _colorLayoutViewModel = colorLayoutViewModel;
        }

        public IXAxisLayoutViewModel XAxisLayoutViewModel
        {
            get { return _xAxisLayoutViewModel; }
        }

        public IYAxisLayoutViewModel YAxisLayoutViewModel
        {
            get { return _yAxisLayoutViewModel; }
        }

        public IColorLayoutViewModel ColorLayoutViewModel
        {
            get { return _colorLayoutViewModel; }
        }
    }
}
