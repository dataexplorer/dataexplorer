﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Columns;

namespace DataExplorer.Domain.Maps.ColorMaps
{
    public interface IColorMapFactory
    {
        ColorMap Create(Column column, ColorPalette colorPalette);
    }
}