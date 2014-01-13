using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Application;
using DataExplorer.Application.Core.Queries;
using DataExplorer.Domain.Rows;

namespace DataExplorer.Application.Rows.Queries
{
    public class GetSelectedRowsQueryHandler : IQueryHandler<GetSelectedRowsQuery, List<Row>>
    {
        private readonly IApplicationStateService _stateService;

        public GetSelectedRowsQueryHandler(IApplicationStateService stateService)
        {
            _stateService = stateService;
        }

        public List<Row> Execute(GetSelectedRowsQuery query)
        {
            return _stateService.GetSelectedRows();
        }
    }
}
