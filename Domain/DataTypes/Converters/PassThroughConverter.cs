using System;

namespace DataExplorer.Domain.DataTypes.Converters
{
    public class PassThroughConverter : IDataTypeConverter
    {
        public object Convert(object source)
        {
            return source;
        }
    }
}
