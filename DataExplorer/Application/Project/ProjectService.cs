using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Serialization;
using DataExplorer.Domain.Events;
using DataExplorer.Domain.Projects;
using DataExplorer.Domain.Rows;
using DataExplorer.Domain.Views;

namespace DataExplorer.Application.Project
{
    public class ProjectService : IProjectService
    {
        private readonly ISerializationService _serializationService;
        private readonly IViewRepository _viewRepository;
        private readonly IRowRepository _rowRepository;

        public ProjectService(
            ISerializationService serializationService,
            IViewRepository viewRepository, 
            IRowRepository rowRepository)
        {
            _serializationService = serializationService;
            _rowRepository = rowRepository;
            _viewRepository = viewRepository;
        }

        public void OpenProject()
        {
            var views = _serializationService.GetViews();

            foreach (var view in views)
                _viewRepository.Add(view);

            var rows = _serializationService.GetRows();

            foreach (var row in rows)
                _rowRepository.Add(row);

            // TODO: This needs to be moved down into the domain
            DomainEvents.Raise(new ProjectOpenedEvent());
        }
    }
}
