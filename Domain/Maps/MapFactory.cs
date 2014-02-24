using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Colors;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Maps.AxisMaps;
using DataExplorer.Domain.Maps.ColorMaps;
using DataExplorer.Domain.Maps.SizeMaps;

namespace DataExplorer.Domain.Maps
{
    public class MapFactory : IMapFactory
    {
        private readonly IAxisMapFactory _axisMapFactory;
        private readonly IColorMapFactory _colorMapFactory;
        private readonly ISizeMapFactory _sizeMapFactory;

        public MapFactory(
            IAxisMapFactory axisMapFactory, 
            IColorMapFactory colorMapFactory,
            ISizeMapFactory sizeMapFactory)
        {
            _axisMapFactory = axisMapFactory;
            _colorMapFactory = colorMapFactory;
            _sizeMapFactory = sizeMapFactory;
        }

        public AxisMap CreateAxisMap(Column column, double targetMin, double targetMax)
        {
            return _axisMapFactory.Create(column, targetMin, targetMax);
        }

        public ColorMap CreateColorMap(Column column, ColorPalette colorPalette)
        {
            return _colorMapFactory.Create(column, colorPalette);
        }

        public SizeMap CreateSizeMap(Column column, double targetMin, double targetMax)
        {
            return _sizeMapFactory.Create(column, targetMin, targetMax);
        }
    }
}
