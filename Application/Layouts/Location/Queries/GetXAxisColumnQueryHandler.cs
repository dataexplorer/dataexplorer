using DataExplorer.Application.Columns;
using DataExplorer.Application.Core.Queries;
using DataExplorer.Application.Views;
using DataExplorer.Domain.Views.ScatterPlots;

namespace DataExplorer.Application.Layouts.Location.Queries
{
    public class GetXAxisColumnQueryHandler 
        : IQueryHandler<GetXAxisColumnQuery, ColumnDto>
    {
        private readonly IViewRepository _repository;
        private readonly IColumnAdapter _adapter;

        public GetXAxisColumnQueryHandler(
            IViewRepository repository,
            IColumnAdapter adapter)
        {
            _repository = repository;
            _adapter = adapter;
        }

        public ColumnDto Execute(GetXAxisColumnQuery query)
        {
            var scatterPlot = _repository.Get<ScatterPlot>();

            var layout = scatterPlot.GetLayout();

            var column = layout.XAxisColumn;

            var columnDto = _adapter.Adapt(column);

            return columnDto;
        }
    }
}
