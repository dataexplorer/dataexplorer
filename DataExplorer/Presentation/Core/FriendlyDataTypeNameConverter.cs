using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataExplorer.Presentation.Core
{
    public class FriendlyDataTypeNameConverter
    {
        public string Convert(Type type)
        {
            if (type == typeof(Int32))
                return "Integer";

            return type.Name;
        }
    }
}
