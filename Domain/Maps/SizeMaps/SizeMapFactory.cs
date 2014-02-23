using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Columns;

namespace DataExplorer.Domain.Maps.SizeMaps
{
    public class SizeMapFactory : ISizeMapFactory
    {
        public SizeMap Create(Column column, double targetMin, double targetMax)
        {
            if (column.Type == typeof(Boolean))
                return new BooleanToSizeMap(targetMin, targetMax);

            if (column.Type == typeof(DateTime))
                return new DateTimeToSizeMap(
                    (DateTime)column.Min,
                    (DateTime)column.Max,
                    targetMin,
                    targetMax);

            if (column.Type == typeof(Double))
                return new FloatToSizeMap(
                    (double)column.Min,
                    (double)column.Max,
                    targetMin,
                    targetMax);

            if (column.Type == typeof(Int32))
                return new IntegerToSizeMap(
                    (int)column.Min,
                    (int)column.Max,
                    targetMin,
                    targetMax);

            if (column.Type == typeof(String))
                return new StringToSizeMap(
                    column.Values.Cast<string>().ToList(),
                    targetMin,
                    targetMax);

            throw new ArgumentException("Column data type is not valid data type for an axis map.");
        }
    }
}
