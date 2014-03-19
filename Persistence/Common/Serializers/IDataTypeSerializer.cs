using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataExplorer.Persistence.Common.Serializers
{
    public interface IDataTypeSerializer
    {
        XElement Serialize(string name, Type type);

        Type Deserialize(XElement xProperty);
    }
}
