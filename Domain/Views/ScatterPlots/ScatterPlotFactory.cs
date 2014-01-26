using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DataExplorer.Domain.Colors;

namespace DataExplorer.Domain.Views.ScatterPlots
{
    public class ScatterPlotFactory : IScatterPlotFactory
    {
        private readonly IColorPaletteFactory _colorPaletteFactory;

        public ScatterPlotFactory(IColorPaletteFactory colorPaletteFactory)
        {
            _colorPaletteFactory = colorPaletteFactory;
        }

        public ScatterPlot Create()
        {
            var palette = _colorPaletteFactory.GetColorPalette("Pastel 1");

            var layout = new ScatterPlotLayout() { ColorPalette = palette };

            var extent = new Rect(-0.1, -0.1, 1.2, 1.2);

            var plots = new List<Plot>();

            return new ScatterPlot(layout, extent, plots);
        }
    }
}
