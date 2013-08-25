using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataExplorer.Application.Importers.Converters
{
    public class PassThroughConverter : IDataTypeConverter
    {
        public object Convert(object source)
        {
            return source;
        }
    }
}
