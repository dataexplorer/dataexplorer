using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Core.Queries;
using DataExplorer.Domain.Columns;

namespace DataExplorer.Application.Columns.Queries
{
    public class GetAllColumnsQueryHandler : IQueryHandler<GetAllColumnsQuery, List<ColumnDto>> 
    {
        private readonly IColumnRepository _repository;
        private readonly IColumnAdapter _adapter;

        public GetAllColumnsQueryHandler(
            IColumnRepository repository,
            IColumnAdapter adapter)
        {
            _repository = repository;
            _adapter = adapter;
        }

        public List<ColumnDto> Execute(GetAllColumnsQuery query)
        {
            var columns = _repository.GetAll();

            var columnDtos = columns
                .Select(p => _adapter.Adapt(p))
                .ToList();

            return columnDtos;
        }
    }
}
