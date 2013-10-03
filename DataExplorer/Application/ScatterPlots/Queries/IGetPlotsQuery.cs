using System.Collections.Generic;

namespace DataExplorer.Application.ScatterPlots.Tasks
{
    public interface IGetPlotsQuery
    {
        List<PlotDto> GetPlots();
    }
}