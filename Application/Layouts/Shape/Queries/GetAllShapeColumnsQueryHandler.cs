using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Columns;
using DataExplorer.Application.Core.Commands;
using DataExplorer.Application.Core.Queries;

namespace DataExplorer.Application.Layouts.Shape.Queries
{
    public class GetAllShapeColumnsQueryHandler 
        : IQueryHandler<GetAllShapeColumnsQuery, List<ColumnDto>>
    {
        public List<ColumnDto> Execute(GetAllShapeColumnsQuery query)
        {
            return new List<ColumnDto>();
        }
    }
}
