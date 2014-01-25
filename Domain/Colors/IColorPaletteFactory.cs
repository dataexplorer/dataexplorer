using System.Collections.Generic;

namespace DataExplorer.Domain.Colors
{
    public interface IColorPaletteFactory
    {
        ColorPalette GetColorPalette(string colorPaletteName);
        List<ColorPalette> GetColorPalettes();
    }
}