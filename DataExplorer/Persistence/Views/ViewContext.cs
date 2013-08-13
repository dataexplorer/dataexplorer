using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.ScatterPlots;

namespace DataExplorer.Persistence.Views
{
    public class ViewContext : IViewContext
    {
        public ViewContext()
        {
            // TODO: Remove this dummy default data
            ScatterPlot = new ScatterPlot();
        }

        public IScatterPlot ScatterPlot { get; set; }
    }
}
