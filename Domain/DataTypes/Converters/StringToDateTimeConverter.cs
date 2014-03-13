using System;

namespace DataExplorer.Domain.DataTypes.Converters
{
    public class StringToDateTimeConverter : IDataTypeConverter
    {
        public object Convert(object source)
        {
            if ((string) source == string.Empty)
                return null;

            return DateTime.Parse((string) source);
        }
    }
}
