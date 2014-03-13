using System;

namespace DataExplorer.Domain.DataTypes.Converters
{
    public interface IDataTypeConverterFactory
    {
        IDataTypeConverter Create(Type sourceType, Type targetType);
    }
}
