﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Columns;

namespace DataExplorer.Domain.Maps.ColorMaps
{
    public class ColorMapFactory : IColorMapFactory
    {
        public ColorMap Create(Column column, ColorPalette colorPalette)
        {
            if (column.Type == typeof(Boolean))
                return new BooleanToColorMap(colorPalette.Colors);

            if (column.Type == typeof(DateTime))
                return new DateTimeToColorMap(
                    (DateTime) column.Min, 
                    (DateTime) column.Max, 
                    colorPalette.Colors);

            if (column.Type == typeof(Double))
                return new FloatToColorMap(
                    (double) column.Min, 
                    (double) column.Max, 
                    colorPalette.Colors);

            if (column.Type == typeof(Int32))
                return new IntegerToColorMap(
                    (int) column.Min, 
                    (int) column.Max, 
                    colorPalette.Colors);

            if (column.Type == typeof(String))
                return new StringToColorMap(
                    column.Values.Cast<string>().ToList(),
                    colorPalette.Colors);

            throw new ArgumentException("Column data type is not a valid data type for a color map.");
        }
    }
}