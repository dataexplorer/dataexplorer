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
using DataExplorer.Persistence.Columns;

namespace DataExplorer.Application.Project
{
    public class ProjectService : IProjectService
    {
        private readonly ISerializationService _serializationService;
        private readonly IColumnRepository _columnRepository;
        private readonly IRowRepository _rowRepository;
        private readonly IViewRepository _viewRepository;

        public ProjectService(
            ISerializationService serializationService,
            IColumnRepository columnRepository,
            IRowRepository rowRepository,
            IViewRepository viewRepository)
        {
            _serializationService = serializationService;
            _columnRepository = columnRepository;
            _rowRepository = rowRepository;
            _viewRepository = viewRepository;
        }

        public void OpenProject()
        {
            var columns = _serializationService.GetColumns();

            foreach (var column in columns)
                _columnRepository.Add(column);
            
            var rows = _serializationService.GetRows();

            foreach (var row in rows)
                _rowRepository.Add(row);

            var views = _serializationService.GetViews();

            foreach (var view in views)
                _viewRepository.Add(view);

            // TODO: This needs to be moved down into the domain
            DomainEvents.Raise(new ProjectOpenedEvent());
        }
    }
}
