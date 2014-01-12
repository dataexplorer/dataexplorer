using System.Collections.Generic;

namespace DataExplorer.Application.Views.ScatterPlots.Queries
{
    public interface IGetPlotsQuery
    {
        List<PlotDto> GetPlots();
    }
}