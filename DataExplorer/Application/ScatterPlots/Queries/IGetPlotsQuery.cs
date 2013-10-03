using System.Collections.Generic;

namespace DataExplorer.Application.ScatterPlots.Queries
{
    public interface IGetPlotsQuery
    {
        List<PlotDto> GetPlots();
    }
}