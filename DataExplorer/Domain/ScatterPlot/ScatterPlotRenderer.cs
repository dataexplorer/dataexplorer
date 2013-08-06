using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataExplorer.Domain.ScatterPlot
{
    public class ScatterPlotRenderer : IScatterPlotRenderer
    {
        public List<Plot> RenderPlots(List<DataRow> rows)
        {
            var plots = new List<Plot>();

            foreach (var dataRow in rows)
            {
                var plot = RenderPlot(dataRow);
                plots.Add(plot);
            }

            return plots;
        }

        private Plot RenderPlot(DataRow dataRow)
        {
            var plot = new Plot();
            plot.X = RenderX(dataRow);
            plot.Y = RenderY(dataRow);
            return plot;
        }

        private double RenderX(DataRow dataRow)
        {
            return Convert.ToDouble(dataRow[0]);
        }

        private double RenderY(DataRow dataRow)
        {
            return Convert.ToDouble(dataRow[1]);
        }
    }
}
