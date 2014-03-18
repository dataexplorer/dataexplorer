using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using DataExplorer.Application.Columns;
using DataExplorer.Domain.Columns;

namespace DataExplorer.Application.Layouts.Base.Queries
{
    public abstract class BaseGetAllLayoutColumnsQueryHandler
    {
        private readonly IColumnRepository _repository;
        private readonly IColumnAdapter _adapter;

        public BaseGetAllLayoutColumnsQueryHandler(
            IColumnRepository repository,
            IColumnAdapter adapter)
        {
            _repository = repository;
            _adapter = adapter;
        }

        public List<ColumnDto> Execute(Predicate<Column> filter)
        {
            var columns = _repository.GetAll();

            var columnDtos = columns
                .Where(p => filter(p))
                .Select(p => _adapter.Adapt(p))
                .ToList();

            return columnDtos;
        }
    }
}
