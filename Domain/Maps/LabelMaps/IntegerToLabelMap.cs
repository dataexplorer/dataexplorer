using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataExplorer.Domain.Maps.LabelMaps
{
    public class IntegerToLabelMap : LabelMap
    {
        public override string Map(object value)
        {
            if (value == null)
                return "Null";

            return Format((int) value);
        }

        // TODO: THis eventually needs to be replaced by project-level formatters
        private string Format(int value)
        {
            return IsLargeNumber(value) 
                ? value.ToString("E2") 
                : value.ToString("G");
        }

        private static bool IsLargeNumber(int value)
        {
            return value <= -1000000 || value >= 1000000;
        }
    }
}
