using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Core.Queries;
using DataExplorer.Domain.Rows;

namespace DataExplorer.Application.Rows.Queries
{
    public class GetAllRowsQuery : IQuery<List<Row>>
    {
    }
}
