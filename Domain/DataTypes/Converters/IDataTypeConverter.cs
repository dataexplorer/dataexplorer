using System;

namespace DataExplorer.Domain.DataTypes.Converters
{
    public interface IDataTypeConverter
    {
        object Convert(object source);
    }
}
