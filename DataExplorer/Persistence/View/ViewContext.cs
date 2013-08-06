using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.ScatterPlot;

namespace DataExplorer.Persistence.View
{
    public class ViewContext : IViewContext
    {
        public ViewContext()
        {
            // TODO: Remove this fake data
            var plot1 = new Plot() { X = 0, Y = 0 };
            var plot2 = new Plot() { X = 1000, Y = 1000 };
            var plots = new List<Plot>() { plot1, plot2 };
            var scatterPlot = new ScatterPlot();
            scatterPlot.SetPlots(plots);
            ScatterPlot = scatterPlot;
        }

        public IScatterPlot ScatterPlot { get; set; }
    }
}
