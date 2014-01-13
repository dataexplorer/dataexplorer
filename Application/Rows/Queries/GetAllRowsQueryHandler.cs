using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Core.Queries;
using DataExplorer.Domain.Rows;

namespace DataExplorer.Application.Rows.Queries
{
    public class GetAllRowsQueryHandler : IQueryHandler<GetAllRowsQuery, List<Row>>
    {
        private readonly IRowRepository _repository;

        public GetAllRowsQueryHandler(IRowRepository repository)
        {
            _repository = repository;
        }

        public List<Row> Execute(GetAllRowsQuery query)
        {
            return _repository.GetAll().ToList();
        }
    }
}
