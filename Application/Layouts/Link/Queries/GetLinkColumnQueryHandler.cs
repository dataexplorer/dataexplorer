using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Columns;
using DataExplorer.Application.Core.Queries;
using DataExplorer.Application.Layouts.Base.Queries;
using DataExplorer.Application.Views;

namespace DataExplorer.Application.Layouts.Link.Queries
{
    public class GetLinkColumnQueryHandler
        : BaseGetLayoutColumnQueryHandler,
        IQueryHandler<GetLinkColumnQuery, ColumnDto>
    {
        public GetLinkColumnQueryHandler(
            IViewRepository repository,
            IColumnAdapter adapter)
            : base(repository, adapter)
        {
        }

        public ColumnDto Execute(GetLinkColumnQuery query)
        {
            return base.Execute(p => p.LinkColumn);
        }
    }
}
