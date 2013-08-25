using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataExplorer.Domain.Converters
{
    public class DataTypeConverterFactory : IDataTypeConverterFactory
    {
        public IDataTypeConverter Create(Type sourceType, Type targetType)
        {
            if (sourceType == typeof(String))
            {
                if (targetType == typeof(Boolean))
                    return new StringToBooleanConverter();

                if (targetType == typeof(DateTime))
                    return new StringToDateTimeConverter();

                if (targetType == typeof(Int32))
                    return new StringToIntegerConverter();

                if (targetType == typeof(Double))
                    return new StringToFloatConverter();

                if (targetType == typeof(String))
                    return new PassThroughConverter();
            }

            throw new ArgumentException("Source type cannot be converted into target type.");
        }
    }
}
