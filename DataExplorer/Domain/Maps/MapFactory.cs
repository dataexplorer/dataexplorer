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
        public IAxisMap CreateAxisMap(Column column, double targetMin, double targetMax)
        {
            if (column.Type == typeof(double))
                return CreateFloatToAxisMap(column, targetMin, targetMax);

            if (column.Type == typeof(bool))
                return CreatBooleanToAxisMap(column, targetMin, targetMax);

            throw new ArgumentException("Column data type is not valid data type for an axis map.");
        }

        private IAxisMap CreatBooleanToAxisMap(Column column, double targetMin, double targetMax)
        {
            return new BooleanToAxisMap(targetMin, targetMax);
        }

        private IAxisMap CreateFloatToAxisMap(Column column, double targetMin, double targetMax)
        {
            return new FloatToAxisMap((double) column.Min, (double) column.Max, targetMin, targetMax);
        }
    }
}
