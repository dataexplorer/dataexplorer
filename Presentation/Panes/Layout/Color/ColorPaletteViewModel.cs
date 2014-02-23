using System;
using System.Collections.Generic;
using System.Linq;
using DataExplorer.Domain.Colors;

namespace DataExplorer.Presentation.Panes.Layout.Color
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

        public override bool Equals(object obj)
        {
            if (!(obj is ColorPaletteViewModel))
                return false;

            var other = (ColorPaletteViewModel) obj;

            return _colorPalette.Name == other._colorPalette.Name;
        }

        public override int GetHashCode()
        {
            return (_colorPalette != null ? _colorPalette.GetHashCode() : 0);
        }
    }
}
