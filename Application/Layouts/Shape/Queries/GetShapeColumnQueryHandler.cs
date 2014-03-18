using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Columns;
using DataExplorer.Application.Core.Queries;
using DataExplorer.Application.Views;

namespace DataExplorer.Application.Layouts.Shape.Queries
{
    public class GetShapeColumnQueryHandler 
        : BaseGetLayoutColumnQueryHandler, 
        IQueryHandler<GetShapeColumnQuery, ColumnDto>
    {
        public GetShapeColumnQueryHandler(
            IViewRepository repository,
            IColumnAdapter adapter)
            : base(repository, adapter)
        {
        }

        public ColumnDto Execute(GetShapeColumnQuery query)
        {
            return base.Execute(p => p.ShapeColumn);
        }
    }
}
