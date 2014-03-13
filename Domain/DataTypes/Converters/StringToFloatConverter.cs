using System;

namespace DataExplorer.Domain.DataTypes.Converters
{
    public class StringToFloatConverter : IDataTypeConverter
    {
        public object Convert(object source)
        {
            if ((string) source == string.Empty)
                return null;

            return Double.Parse((string) source);
        }
    }
}
