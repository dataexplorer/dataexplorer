using System;

namespace DataExplorer.Domain.DataTypes.Converters
{
    public class StringToIntegerConverter : IDataTypeConverter
    {
        public object Convert(object source)
        {
            if ((string) source == string.Empty)
                return null;

            return Int32.Parse((string) source);
        }
    }
}
