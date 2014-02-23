using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace DataExplorer.Persistence.Columns.Serializers
{
    public interface IColumnDataTypeSerializer
    {
        List<Type> Deserialize(XElement xColumns);
    }
}
