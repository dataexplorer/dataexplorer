using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace DataExplorer.Persistence.Common.Serializers
{
    public interface IPropertySerializer
    {
        XElement Serialize<T>(string name, T value);

        XElement SerializeList<T>(string listName, List<T> value);

        T Deserialize<T>(XElement xProperty);

        List<T> DeserializeList<T>(XElement xProperty);

        object Deserialize(XElement xProperty, Type type);
    }
}
