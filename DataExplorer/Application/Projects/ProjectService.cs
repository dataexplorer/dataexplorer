using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Serialization;
using DataExplorer.Domain.Events;
using DataExplorer.Domain.Projects;
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

            // TODO: Should this be moved down into the domain?
            DomainEvents.Raise(new ProjectOpenedEvent());
        }

        public void CloseProject()
        {
            _dataContext.Clear();

            // TODO: Should this be moved down into the domain?
            DomainEvents.Raise(new ProjectClosedEvent());
        }
    }
}
