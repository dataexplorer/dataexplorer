using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain;

namespace DataExplorer.Presentation.Views.ScatterPlots.Layout.Color
{
    public class ColorPaletteViewModel
    {
        private readonly ColorPalette _colorPalette;

        public ColorPaletteViewModel(ColorPalette colorPalette)
        {
            _colorPalette = colorPalette;
        }

        public List<System.Windows.Media.Color> Colors
        {
            get 
            { 
                return _colorPalette.Colors
                    .Select(p => System.Windows.Media.Color.FromRgb(p.Red, p.Green, p.Blue))
                    .ToList(); 
            } 
        }

        public ColorPalette ColorPalette
        {
            get { return _colorPalette; }
        }
    }
}
