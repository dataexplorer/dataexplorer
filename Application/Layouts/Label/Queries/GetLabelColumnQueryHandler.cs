using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Columns;
using DataExplorer.Application.Core.Queries;
using DataExplorer.Application.Views;

namespace DataExplorer.Application.Layouts.Label.Queries
{
    public class GetLabelColumnQueryHandler
        : BaseGetLayoutColumnQueryHandler,
        IQueryHandler<GetLabelColumnQuery, ColumnDto>
    {
        public GetLabelColumnQueryHandler(
            IViewRepository repository,
            IColumnAdapter adapter)
            : base(repository, adapter)
        {
        }

        public ColumnDto Execute(GetLabelColumnQuery query)
        {
            return base.Execute(p => p.LabelColumn);
        }
    }
}
