using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataExplorer.Domain.ScatterPlot
{
    public interface IScatterPlotRenderer
    {
        List<Plot> RenderPlots(List<DataRow> rows);
    }
}
