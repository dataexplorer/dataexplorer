using System;

namespace DataExplorer.Presentation.Core.Converters
{
    public class FriendlyDataTypeNameConverter
    {
        public string Convert(Type type)
        {
            if (type == typeof(Int32))
                return "Integer";

            return type.Name;
        }
    }
}
