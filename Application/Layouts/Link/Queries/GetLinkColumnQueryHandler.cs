using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Columns;
using DataExplorer.Application.Core.Queries;

namespace DataExplorer.Application.Layouts.Link.Queries
{
    public class GetLinkColumnQueryHandler : IQueryHandler<GetLinkColumnQuery, ColumnDto>
    {
        public ColumnDto Execute(GetLinkColumnQuery query)
        {
            return null;
        }
    }
}
