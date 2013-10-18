using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Events;
using DataExplorer.Domain.Projects;
using DataExplorer.Infrastructure.Serialization;
using DataExplorer.Persistence;

namespace DataExplorer.Application.Projects
{
    public class ProjectService : IProjectService
    {
        private readonly ISerializationService _serializationService;
        private readonly IDataContext _dataContext;
        
        public ProjectService(
            ISerializationService serializationService,
            IDataContext dataContext)
        {
            _serializationService = serializationService;
            _dataContext = dataContext;
        }

        public void OpenProject()
        {
            var project = _serializationService.GetProject();

            _dataContext.SetProject(project);

            DomainEvents.Raise(new ProjectOpenedEvent());
        }

        public void CloseProject()
        {
            _dataContext.Clear();

            DomainEvents.Raise(new ProjectClosedEvent());
        }
    }
}
