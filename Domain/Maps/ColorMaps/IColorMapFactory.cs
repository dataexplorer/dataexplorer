using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Colors;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Layouts;

namespace DataExplorer.Domain.Maps.ColorMaps
{
    public interface IColorMapFactory
    {
        ColorMap Create(Column column, ColorPalette colorPalette, SortOrder sortOrder);
    }
}
