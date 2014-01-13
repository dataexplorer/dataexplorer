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
    public class GetLastSelectedRowQueryHandler : IQueryHandler<GetLastSelectedRowQuery, Row>
    {
        private readonly IApplicationStateService _stateService;

        public GetLastSelectedRowQueryHandler(IApplicationStateService stateService)
        {
            _stateService = stateService;
        }

        public Row Execute(GetLastSelectedRowQuery query)
        {
            return _stateService
                .GetSelectedRows()
                .LastOrDefault();
        }
    }
}
