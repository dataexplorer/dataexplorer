using System.Collections.Generic;
using DataExplorer.Domain.Colors;
using DataExplorer.Domain.Maps;
using DataExplorer.Domain.Rows;

namespace DataExplorer.Domain.Views.ScatterPlots
{
    public class ScatterPlotRenderer : IScatterPlotRenderer
    {
        private static Color DefaultColor = new Color(173, 216, 230);

        private readonly IMapFactory _factory;

        public ScatterPlotRenderer(IMapFactory factory)
        {
            _factory = factory;
        }

        public List<Plot> RenderPlots(List<Row> rows, ScatterPlotLayout layout)
        {
            var xAxisMap = layout.XAxisColumn != null 
                ? _factory.CreateAxisMap(layout.XAxisColumn, 0d, 1d) 
                : null;

            var yAxisMap = layout.YAxisColumn != null
                ? _factory.CreateAxisMap(layout.YAxisColumn, 0d, 1d)
                : null;

            var colorMap = layout.ColorColumn != null
                ? _factory.CreateColorMap(layout.ColorColumn, layout.ColorPalette)
                : null;

            var sizeMap = layout.SizeColumn != null
                ? _factory.CreateSizeMap(layout.SizeColumn, layout.LowerSize, layout.UpperSize)
                : null;

            var labelMap = layout.LabelColumn != null
                ? _factory.CreateLabelMap(layout.LabelColumn)
                : null;

            var plots = new List<Plot>();
            
            foreach (var row in rows)
            {
                var plot = new Plot();

                plot.Id = row.Id;

                plot.X = layout.XAxisColumn != null
                    ? xAxisMap.Map(row[layout.XAxisColumn.Index]) ?? 0.0
                    : 0.0;

                plot.Y = layout.YAxisColumn != null
                    ? yAxisMap.Map(row[layout.YAxisColumn.Index]) ?? 0.0
                    : 0.0;

                plot.Color = layout.ColorColumn != null
                    ? colorMap.Map(row[layout.ColorColumn.Index])
                    : DefaultColor;

                plot.Size = layout.SizeColumn != null
                    ? sizeMap.Map(row[layout.SizeColumn.Index]) ?? 0.0
                    : layout.UpperSize;

                plot.Label = layout.LabelColumn != null
                    ? labelMap.Map(row[layout.LabelColumn.Index])
                    : null;

                plots.Add(plot);
            }
            
            return plots;
        }
    }
}
