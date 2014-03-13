using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Columns;
using DataExplorer.Application.Core.Queries;

namespace DataExplorer.Application.Layouts.Link.Queries
{
    public class GetAllLinkColumnsQueryHandler 
        : IQueryHandler<GetAllLinkColumnsQuery, List<ColumnDto>>
    {
        public List<ColumnDto> Execute(GetAllLinkColumnsQuery query)
        {
            return new List<ColumnDto>();
        }
    }
}
