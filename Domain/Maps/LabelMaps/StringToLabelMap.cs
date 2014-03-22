using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataExplorer.Domain.Maps.LabelMaps
{
    public class StringToLabelMap : LabelMap
    {
        public override string Map(object value)
        {
            if (value == string.Empty)
                return "[Empty]";

            if (value == null)
                return "[Null]";

            return (string) value;
        }
    }
}
