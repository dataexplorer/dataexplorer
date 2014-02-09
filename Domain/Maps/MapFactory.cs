using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Colors;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Maps.AxisMaps;
using DataExplorer.Domain.Maps.ColorMaps;

namespace DataExplorer.Domain.Maps
{
    public class MapFactory : IMapFactory
    {
        private readonly IAxisMapFactory _axisMapFactory;
        private readonly IColorMapFactory _colorMapFactory;

        public MapFactory(
            IAxisMapFactory axisMapFactory, 
            IColorMapFactory colorMapFactory)
        {
            _axisMapFactory = axisMapFactory;
            _colorMapFactory = colorMapFactory;
        }

        public AxisMap CreateAxisMap(Column column, double targetMin, double targetMax)
        {
            return _axisMapFactory.Create(column, targetMin, targetMax);
        }

        public ColorMap CreateColorMap(Column column, ColorPalette colorPalette)
        {
            return _colorMapFactory.Create(column, colorPalette);
        }
    }
}
