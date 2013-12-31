using System.Collections.Generic;
using DataExplorer.Domain.Rows;

namespace DataExplorer.Domain.Views.ScatterPlots
{
    public interface IScatterPlotRenderer
    {
        List<Plot> RenderPlots(List<Row> rows, ScatterPlotLayout layout);
    }
}
