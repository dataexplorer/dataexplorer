using System;
using System.Windows.Media.Imaging;

namespace DataExplorer.Presentation.Core.Converters
{
    public class FriendlyDataTypeNameConverter
    {
        public string Convert(Type type)
        {
            if (type == typeof(Double))
                return "Float";

            if (type == typeof(Int32))
                return "Integer";

            if (type == typeof(BitmapImage))
                return "Image";

            return type.Name;
        }
    }
}
