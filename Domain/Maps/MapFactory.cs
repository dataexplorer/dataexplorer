using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Maps.AxisMaps;

namespace DataExplorer.Domain.Maps
{
    public class MapFactory : IMapFactory
    {
        private readonly IAxisMapFactory _axisMapFactory;

        public MapFactory(IAxisMapFactory axisMapFactory)
        {
            _axisMapFactory = axisMapFactory;
        }

        public AxisMap CreateAxisMap(Column column, double targetMin, double targetMax)
        {
            return _axisMapFactory.Create(column, targetMin, targetMax);
        }
    }
}
