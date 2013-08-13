using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Rows;

namespace DataExplorer.Domain.ScatterPlots
{
    public class ScatterPlotRenderer : IScatterPlotRenderer
    {
        public List<Plot> RenderPlots(List<Row> rows)
        {
            var plots = new List<Plot>();

            foreach (var row in rows)
            {
                var plot = RenderPlot(row);
                plots.Add(plot);
            }

            return plots;
        }

        private Plot RenderPlot(Row row)
        {
            var plot = new Plot();
            plot.X = RenderX(row);
            plot.Y = RenderY(row);
            return plot;
        }

        private double RenderX(Row row)
        {
            return Convert.ToDouble(row[0]);
        }

        private double RenderY(Row dataRow)
        {
            return Convert.ToDouble(dataRow[1]);
        }
    }
}
