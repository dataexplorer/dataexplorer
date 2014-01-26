using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataExplorer.Domain.Views.ScatterPlots
{
    public interface IScatterPlotFactory
    {
        ScatterPlot Create();
    }
}
