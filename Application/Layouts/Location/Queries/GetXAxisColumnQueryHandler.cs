using DataExplorer.Application.Columns;
using DataExplorer.Application.Core.Queries;
using DataExplorer.Application.Views;

namespace DataExplorer.Application.Layouts.Location.Queries
{
    public class GetXAxisColumnQueryHandler
           : BaseGetLayoutColumnQueryHandler,
           IQueryHandler<GetXAxisColumnQuery, ColumnDto>
    {
        public GetXAxisColumnQueryHandler(
            IViewRepository repository,
            IColumnAdapter adapter)
            : base(repository, adapter)
        {
        }

        public ColumnDto Execute(GetXAxisColumnQuery query)
        {
            return base.Execute(p => p.XAxisColumn);
        }
    }
}
