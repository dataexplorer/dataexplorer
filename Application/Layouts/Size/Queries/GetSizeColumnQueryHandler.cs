using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Columns;
using DataExplorer.Application.Core.Queries;
using DataExplorer.Application.Layouts.Base.Queries;
using DataExplorer.Application.Views;

namespace DataExplorer.Application.Layouts.Size.Queries
{
    public class GetSizeColumnQueryHandler
        : BaseGetLayoutColumnQueryHandler,
        IQueryHandler<GetSizeColumnQuery, ColumnDto>
    {
        public GetSizeColumnQueryHandler(
            IViewRepository repository,
            IColumnAdapter adapter)
            : base(repository, adapter)
        {
        }

        public ColumnDto Execute(GetSizeColumnQuery query)
        {
            return base.Execute(p => p.SizeColumn);
        }
    }
}
