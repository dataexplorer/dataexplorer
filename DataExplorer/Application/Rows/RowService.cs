using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Application;
using DataExplorer.Domain.Rows;

namespace DataExplorer.Application.Rows
{
    public class RowService : IRowService
    {
        private readonly IRowRepository _repository;
        private readonly IApplicationStateService _stateService;

        public RowService(
            IRowRepository repository, 
            IApplicationStateService stateService)
        {
            _repository = repository;
            _stateService = stateService;
        }

        public IEnumerable<Row> GetAll()
        {
            return _repository.GetAll();
        }

        public void SetSelectedRows(IEnumerable<Row> rows)
        {
            _stateService.SelectedRows = rows.ToList();
        }

        public IEnumerable<Row> GetSelectedRows()
        {
            return _stateService.SelectedRows;
        }
    }
}
