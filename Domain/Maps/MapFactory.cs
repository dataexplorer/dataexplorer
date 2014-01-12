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
            if (column.Type == typeof(Boolean))
                return new BooleanToAxisMap(targetMin, targetMax);

            if (column.Type == typeof(DateTime))
                return new DateTimeToAxisMap((DateTime) column.Min, (DateTime) column.Max, targetMin, targetMax);

            if (column.Type == typeof(Double))
                return new FloatToAxisMap((double) column.Min, (double) column.Max, targetMin, targetMax);

            if (column.Type == typeof(Int32))
                return new IntegerToAxisMap((int) column.Min, (int) column.Max, targetMin, targetMax);

            if (column.Type == typeof(String))
                return new StringToAxisMap(column.Values.Cast<string>().ToList(), targetMin, targetMax);
            
            throw new ArgumentException("Column data type is not valid data type for an axis map.");
        }
    }
}
