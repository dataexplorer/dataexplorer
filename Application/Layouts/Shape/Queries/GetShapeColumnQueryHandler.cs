using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Columns;
using DataExplorer.Application.Core.Queries;

namespace DataExplorer.Application.Layouts.Shape.Queries
{
    public class GetShapeColumnQueryHandler 
        : IQueryHandler<GetShapeColumnQuery, ColumnDto>
    {
        public ColumnDto Execute(GetShapeColumnQuery query)
        {
            return null;
        }
    }
}
