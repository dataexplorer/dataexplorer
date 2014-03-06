using DataExplorer.Application.Columns;
using DataExplorer.Application.Core.Queries;
using DataExplorer.Application.Views;
using DataExplorer.Domain.Views.ScatterPlots;

namespace DataExplorer.Application.Layouts.Location.Queries
{
    public class GetYAxisColumnQueryHandler 
        : IQueryHandler<GetYAxisColumnQuery, ColumnDto>
    {
        private readonly IViewRepository _repository;
        private readonly IColumnAdapter _adapter;

        public GetYAxisColumnQueryHandler(
            IViewRepository repository,
            IColumnAdapter adapter)
        {
            _repository = repository;
            _adapter = adapter;
        }

        public ColumnDto Execute(GetYAxisColumnQuery query)
        {
            var scatterPlot = _repository.Get<ScatterPlot>();

            var layout = scatterPlot.GetLayout();

            var column = layout.YAxisColumn;

            var columnDto = _adapter.Adapt(column);

            return columnDto;
        }
    }
}
