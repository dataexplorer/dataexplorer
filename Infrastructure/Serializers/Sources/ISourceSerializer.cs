using System.Xml.Linq;
using DataExplorer.Domain.Sources;

namespace DataExplorer.Infrastructure.Serializers.Sources
{
    public interface ISourceSerializer
    {
        XElement Serialize(ISource source);

        ISource Deserialize(XElement xSource);
    }
}
