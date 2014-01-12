using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataExplorer.Domain.Converters
{
    public class StringToBooleanConverter : IDataTypeConverter
    {
        public object Convert(object source)
        {
            if ((string) source == string.Empty)
                return null;

            return Boolean.Parse((string) source);
        }
    }
}
