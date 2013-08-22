using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Maps;
using DataExplorer.Domain.Rows;

namespace DataExplorer.Domain.ScatterPlots
{
    public class ScatterPlotRenderer : IScatterPlotRenderer
    {
        private readonly IMapFactory _factory;

        public ScatterPlotRenderer(IMapFactory factory)
        {
            _factory = factory;
        }

        public List<Plot> RenderPlots(List<Row> rows, ScatterPlotLayout layout)
        {
            var xAxisMap = layout.XAxisColumn != null 
                ? _factory.CreateAxisMap(layout.XAxisColumn, 0d, 1000d) 
                : null;

            var yAxisMap = layout.YAxisColumn != null
                ? _factory.CreateAxisMap(layout.YAxisColumn, 0d, 1000d)
                : null;

            var plots = new List<Plot>();
            foreach (var row in rows)
            {
                var plot = new Plot();

                plot.X = layout.XAxisColumn != null
                    ? xAxisMap.Map(row[layout.XAxisColumn.Index])
                    : 0.0;

                plot.Y = layout.YAxisColumn != null
                    ? yAxisMap.Map(row[layout.YAxisColumn.Index])
                    : 0.0;

                plots.Add(plot);
            }
            
            return plots;
        }
    }
}
