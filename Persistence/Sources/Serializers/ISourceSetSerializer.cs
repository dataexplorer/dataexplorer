using System;
using System.Collections.Generic;
using System.Xml.Linq;
using DataExplorer.Domain.Sources;

namespace DataExplorer.Persistence.Sources.Serializers
{
    public interface ISourceSetSerializer
    {
        XElement Serialize(IEnumerable<Source> sources);

        IEnumerable<Source> Deserialize(XElement xSources);
    }
}
