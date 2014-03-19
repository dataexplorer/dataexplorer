using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Xml.Linq;

namespace DataExplorer.Persistence.Common.Serializers
{
    public class DataTypeSerializer : IDataTypeSerializer
    {
        private const string BooleanTag = "Boolean";
        private const string DateTimeTag = "DateTime";
        private const string FloatTag = "Float";
        private const string IntegerTag = "Integer";
        private const string StringTag = "Text";
        private const string ImageTag = "Image";

        private Dictionary<Type, string> _map = new Dictionary<Type, string>
        {
            { typeof(Boolean), BooleanTag },
            { typeof(DateTime), DateTimeTag },
            { typeof(Double), FloatTag },
            { typeof(Int32), IntegerTag },
            { typeof(String), StringTag },
            { typeof(BitmapImage), ImageTag },
        };

        private Dictionary<string, Type> _deMap = new Dictionary<string, Type>
        {
            { BooleanTag, typeof(Boolean) },
            { DateTimeTag, typeof(DateTime) },
            { FloatTag, typeof(Double) },
            { IntegerTag, typeof(Int32) },
            { StringTag, typeof(String) },
            { ImageTag, typeof(BitmapImage) },
        };

        public XElement Serialize(string name, Type type)
        {
            var value = _map[type];

            if (value == null)
                throw new ArgumentException("Type cannot be serialized because it it not recognized.");

            return new XElement(name, value);
        }

        public Type Deserialize(XElement xProperty)
        {
            var value = _deMap[(String) xProperty];

            if (value == null)
                throw new ArgumentException("Type cannot be deserialized because it it not recognized.");

            return value;
        }
    }
}
