using DataExplorer.Domain.Projects;

namespace DataExplorer.Infrastructure.Serialization
{
    public interface ISerializationService
    {
        Project GetProject();
    }
}
