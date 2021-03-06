﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Colors;
using DataExplorer.Domain.Maps.ColorMaps;

namespace DataExplorer.Application.Legends.Colors.Factories
{
    public interface IIntegerColorLegendFactory
    {
        IEnumerable<ColorLegendItemDto> Create(ColorMap map, List<int?> values, ColorPalette palette);
    }
}
