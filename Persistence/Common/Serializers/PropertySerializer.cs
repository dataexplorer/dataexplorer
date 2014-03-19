using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Xml.Linq;

namespace DataExplorer.Persistence.Common.Serializers
{
    public class PropertySerializer : IPropertySerializer
    {
        private readonly IDataTypeSerializer _dataTypeSerializer;

        private const string PropertyCannotBeDeserialized =
            "Property cannot be deserialized because the data type is not recognized.";

        private const string ItemName = "item";

        public PropertySerializer(IDataTypeSerializer dataTypeSerializer)
        {
            _dataTypeSerializer = dataTypeSerializer;
        }

        public XElement SerializeList<T>(string listName, List<T> values)
        {
            var xList = new XElement(listName);

            foreach (var value in values)
            {
                var xItem = Serialize(ItemName, value);

                xList.Add(xItem);
            }

            return xList;
        }

        public XElement Serialize<T>(string name, T value)
        {
            if (typeof (T) == typeof (Type))
                return _dataTypeSerializer.Serialize(name, value as Type);

            return new XElement(name, value);
        }

        public List<T> DeserializeList<T>(XElement xProperty)
        {
            var list = new List<T>();

            foreach (var xItem in xProperty.Elements())
            {
                var item = Deserialize<T>(xItem);

                list.Add(item);
            }

            return list;
        }

        public T Deserialize<T>(XElement xProperty)
        {
            return (T) Deserialize(xProperty, typeof(T));
        }

        public object Deserialize(XElement xProperty, Type type)
        {
            if (type == typeof(Boolean))
                return (Boolean) xProperty;

            if (type == typeof(DateTime))
                return (DateTime) xProperty;

            if (type == typeof(Int32))
                return (Int32) xProperty;

            if (type == typeof(Double))
                return (Double) xProperty;

            if (type == typeof(String))
                return (String) xProperty;

            if (type == typeof(Boolean?))
                return string.IsNullOrEmpty(xProperty.Value)
                    ? null
                    : (Boolean?)xProperty;

            if (type == typeof(DateTime?))
                return string.IsNullOrEmpty(xProperty.Value)
                    ? null
                    : (DateTime?)xProperty;

            if (type == typeof(Double?))
                return string.IsNullOrEmpty(xProperty.Value)
                    ? null
                    : (Double?)xProperty;

            if (type == typeof(Int32?))
                return string.IsNullOrEmpty(xProperty.Value)
                    ? null
                    : (Int32?) xProperty;

            if (type == typeof(Rect))
                return DeserializeRect(xProperty);

            if (type.BaseType == typeof (Enum))
                return Enum.Parse(type, xProperty.Value);

            if (type == typeof (BitmapImage))
                return string.IsNullOrEmpty(xProperty.Value) 
                    ? null 
                    : new BitmapImage(new Uri(xProperty.Value));

            if (type == typeof(Type))
                return _dataTypeSerializer.Deserialize(xProperty);

            throw new ArgumentException(PropertyCannotBeDeserialized);
        }

        private Rect DeserializeRect(XElement xProperty)
        {
            var values = xProperty.Value
                .Split(',')
                .Select(double.Parse)
                .ToList();

            var rect = new Rect(values[0], values[1], values[2], values[3]);

            return rect;
        }
    }
}
