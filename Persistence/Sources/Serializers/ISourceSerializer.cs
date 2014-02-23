using System.Xml.Linq;
using DataExplorer.Domain.Sources;

namespace DataExplorer.Persistence.Sources.Serializers
{
    public interface ISourceSerializer
    {
        XElement Serialize(Source source);

        Source Deserialize(XElement xSource);
    }
}
