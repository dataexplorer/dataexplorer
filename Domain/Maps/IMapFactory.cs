using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Maps.ColorMaps;

namespace DataExplorer.Domain.Maps
{
    public interface IMapFactory
    {
        AxisMap CreateAxisMap(Column column, double targetMin, double targetMax);

        ColorMap CreateColorMap(Column column, ColorPalette colorPalette);
    }
}
