using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Layouts;

namespace DataExplorer.Domain.Maps.AxisMaps
{
    public class AxisMapFactory : IAxisMapFactory
    {
        public AxisMap Create(Column column, double targetMin, double targetMax, SortOrder sortOrder)
        {
            if (column.DataType == typeof(Boolean))
                return new BooleanToAxisMap(
                    targetMin, 
                    targetMax,
                    sortOrder);

            if (column.DataType == typeof(DateTime))
                return new DateTimeToAxisMap(
                    (DateTime) column.Min, 
                    (DateTime) column.Max, 
                    targetMin, 
                    targetMax,
                    sortOrder);

            if (column.DataType == typeof(Double))
                return new FloatToAxisMap(
                    (double) column.Min, 
                    (double) column.Max, 
                    targetMin, 
                    targetMax,
                    sortOrder);

            if (column.DataType == typeof(Int32))
                return new IntegerToAxisMap(
                    (int) column.Min, 
                    (int) column.Max, 
                    targetMin, 
                    targetMax,
                    sortOrder);

            if (column.DataType == typeof(String))
                return new StringToAxisMap(
                    column.Values.Cast<string>().ToList(), 
                    targetMin, 
                    targetMax,
                    sortOrder);

            throw new ArgumentException("Column data type is not valid data type for an axis map.");
        }
    }
}
