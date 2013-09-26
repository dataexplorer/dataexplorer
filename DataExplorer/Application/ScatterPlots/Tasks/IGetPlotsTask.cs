using System.Collections.Generic;

namespace DataExplorer.Application.ScatterPlots.Tasks
{
    public interface IGetPlotsTask
    {
        List<PlotDto> GetPlots();
    }
}