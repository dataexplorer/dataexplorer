using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.ScatterPlot;

namespace DataExplorer.Application.ScatterPlot
{
    public interface IScatterPlotAdapter
    {
        List<PlotDto> Adapt(List<Plot> plots);
    }
}
