using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataExplorer.Infrastructure.Serializers.Columns
{
    public interface IColumnDataTypeSerializer
    {
        List<Type> Deserialize(XElement xColumns);
    }
}
