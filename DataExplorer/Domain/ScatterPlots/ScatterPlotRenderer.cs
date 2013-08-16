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
        private ScatterPlotLayout _layout;

        public List<Plot> RenderPlots(List<Row> rows, ScatterPlotLayout layout)
        {
            // TODO: Should I use a field or just pass this into function?
            _layout = layout;

            var plots = rows.Select(p => RenderPlot(p)).ToList();
            
            return plots;
        }

        private Plot RenderPlot(Row row)
        {
            var plot = new Plot
            {
                X = RenderX(row),
                Y = RenderY(row)
            };
            return plot;
        }

        private double RenderX(Row row)
        {
            return _layout.XAxisColumn != null 
                ? Convert.ToDouble(row[_layout.XAxisColumn.Index])
                : 0.0;
        }

        private double RenderY(Row dataRow)
        {
            return Convert.ToDouble(dataRow[1]);
        }
    }
}
