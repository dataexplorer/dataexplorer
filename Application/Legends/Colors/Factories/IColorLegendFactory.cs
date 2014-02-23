using System;
using System.Collections.Generic;
using DataExplorer.Domain.Colors;
using DataExplorer.Domain.Maps.ColorMaps;

namespace DataExplorer.Application.Legends.Colors.Factories
{
    public interface IColorLegendFactory
    {
        IEnumerable<ColorLegendItemDto> Create(Type type, ColorMap map, List<object> values, ColorPalette palette);
    }
}
