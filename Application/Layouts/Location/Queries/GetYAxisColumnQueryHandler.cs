using DataExplorer.Application.Columns;
using DataExplorer.Application.Core.Queries;
using DataExplorer.Application.Views;

namespace DataExplorer.Application.Layouts.Location.Queries
{
    public class GetYAxisColumnQueryHandler
           : BaseGetLayoutColumnQueryHandler,
           IQueryHandler<GetYAxisColumnQuery, ColumnDto>
    {
        public GetYAxisColumnQueryHandler(
            IViewRepository repository,
            IColumnAdapter adapter)
            : base(repository, adapter)
        {
        }

        public ColumnDto Execute(GetYAxisColumnQuery query)
        {
            return base.Execute(p => p.YAxisColumn);
        }
    }
}
