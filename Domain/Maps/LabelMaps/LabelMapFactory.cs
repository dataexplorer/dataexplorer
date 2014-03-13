using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Columns;

namespace DataExplorer.Domain.Maps.LabelMaps
{
    public class LabelMapFactory : ILabelMapFactory
    {
        public LabelMap Create(Column column)
        {
            if (column.DataType == typeof(Boolean))
                return new BooleanToLabelMap();

            if (column.DataType == typeof (DateTime))
                return new DateTimeToLabelMap();

            if (column.DataType == typeof(Double))
                return new FloatToLabelMap();

            if (column.DataType == typeof(Int32))
                return new IntegerToLabelMap();

            if (column.DataType == typeof(String))
                return new StringToLabelMap();

            throw new ArgumentException("Column data type is not valid data type for an axis map.");
        }
    }
}
