using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.ScatterPlots;

namespace DataExplorer.Application.ScatterPlots
{
    public interface IScatterPlotAdapter
    {
        List<PlotDto> Adapt(List<Plot> plots);
    }
}
