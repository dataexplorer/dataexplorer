using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DataExplorer.Domain.Views.ScatterPlots;

namespace DataExplorer.Domain.Views
{
    public class ViewFactory : IViewFactory
    {
        private readonly IScatterPlotFactory _scatterPlotFactory;

        public ViewFactory(IScatterPlotFactory scatterPlotFactory)
        {
            _scatterPlotFactory = scatterPlotFactory;
        }

        public View Create<T>()
        {
            if (typeof (T) == typeof (ScatterPlot))
                return _scatterPlotFactory.Create();

            throw new ArgumentException("View could not be created because view type is not recognized.");
        }
    }
}
