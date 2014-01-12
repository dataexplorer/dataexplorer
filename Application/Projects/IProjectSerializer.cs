using System.Xml.Linq;
using DataExplorer.Domain.Projects;

namespace DataExplorer.Application.Projects
{
    public interface IProjectSerializer
    {
        XElement Serialize(Project project);

        Project Deserialize(XElement xProject);
    }
}
