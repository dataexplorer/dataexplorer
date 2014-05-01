using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Colors;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Layouts;
using DataExplorer.Domain.Maps.AxisMaps;
using DataExplorer.Domain.Maps.ColorMaps;
using DataExplorer.Domain.Maps.LabelMaps;
using DataExplorer.Domain.Maps.SizeMaps;

namespace DataExplorer.Domain.Maps
{
    public interface IMapFactory
    {
        AxisMap CreateAxisMap(Column column, double targetMin, double targetMax, SortOrder sortOrder);

        ColorMap CreateColorMap(Column column, ColorPalette colorPalette, SortOrder sortOrder);

        SizeMap CreateSizeMap(Column column, double targetMin, double targetMax, SortOrder sortOrder);

        LabelMap CreateLabelMap(Column column);
    }
}
