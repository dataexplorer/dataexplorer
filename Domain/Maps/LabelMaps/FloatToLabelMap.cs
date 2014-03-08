using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataExplorer.Domain.Maps.LabelMaps
{
    public class FloatToLabelMap : LabelMap
    {
        public override string Map(object value)
        {
            if (value == null)
                return "Null";

            return Format((double) value);
        }

        // TODO: This needs to eventually be handled by project-level formatters
        private string Format(double value)
        {
            return IsLargeNumber(value)
                ? value.ToString("E2")
                : value.ToString("N2");
        }

        private static bool IsLargeNumber(double value)
        {
            return value <= -1000000d || value >= 1000000d
                || (value >= -0.001d && value <= 0.001d && value != 0d);
        }
    }
}
