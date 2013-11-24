using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Application;
using DataExplorer.Application.Core.Events;
using DataExplorer.Domain.Rows;

namespace DataExplorer.Application.Rows
{
    public class RowService : IRowService
    {
        private readonly IRowRepository _repository;
        private readonly IApplicationStateService _stateService;
        private readonly IEventBus _eventBus;

        public RowService(
            IRowRepository repository, 
            IApplicationStateService stateService,
            IEventBus eventBus)
        {
            _repository = repository;
            _stateService = stateService;
            _eventBus = eventBus;
        }

        public IEnumerable<Row> GetAll()
        {
            return _repository.GetAll();
        }

        public void SetSelectedRows(IEnumerable<Row> rows)
        {
            _stateService.SelectedRows = rows.ToList();

            _eventBus.Raise(new SelectedRowsChangedEvent());
        }

        public IEnumerable<Row> GetSelectedRows()
        {
            return _stateService.SelectedRows;
        }
    }
}
