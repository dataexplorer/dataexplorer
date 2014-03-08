using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataExplorer.Domain.Maps.LabelMaps
{
    public class DateTimeToLabelMap : LabelMap
    {
        public override string Map(object value)
        {
            if (value == null)
                return "Null";

            return ((DateTime) value).ToString();
        }
    }
}
