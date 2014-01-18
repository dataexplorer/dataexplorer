using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DataExplorer.Domain.Sources;

namespace DataExplorer.Infrastructure.Serializers.Sources
{
    public interface ISourceSetSerializer
    {
        XElement Serialize(IEnumerable<Source> sources);

        IEnumerable<Source> Deserialize(XElement xSources);
    }
}
