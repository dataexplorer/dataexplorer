using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Columns;
using DataExplorer.Application.Core.Queries;
using DataExplorer.Domain.Semantics;

namespace DataExplorer.Application.Layouts.Link.Queries
{
    public class GetAllLinkColumnsQueryHandler 
        : IQueryHandler<GetAllLinkColumnsQuery, List<ColumnDto>>
    {
        private readonly IColumnRepository _repository;
        private readonly IColumnAdapter _adapter;

        public GetAllLinkColumnsQueryHandler(
            IColumnRepository repository,
            IColumnAdapter adapter)
        {
            _repository = repository;
            _adapter = adapter;
        }

        public List<ColumnDto> Execute(GetAllLinkColumnsQuery query)
        {
            var columns = _repository.GetAll();

            var columnDtos = columns
                .Where(p => p.SemanticType == SemanticType.Uri)
                .Select(p => _adapter.Adapt(p))
                .ToList();

            return columnDtos;
        }
    }
}
