using System.Xml.Linq;
using DataExplorer.Domain.Projects;

namespace DataExplorer.Infrastructure.Serializers
{
    public interface IProjectSerializer
    {
        XElement Serialize(Project project);

        Project Deserialize(XElement xProject);
    }
}
