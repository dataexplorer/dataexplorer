using System;

namespace DataExplorer.Domain.DataTypes.Converters
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
