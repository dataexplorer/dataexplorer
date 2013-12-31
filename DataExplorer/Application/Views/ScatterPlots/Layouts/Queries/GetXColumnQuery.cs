using DataExplorer.Application.Columns;
using DataExplorer.Domain.Views;
using DataExplorer.Domain.Views.ScatterPlots;

namespace DataExplorer.Application.Views.ScatterPlots.Layouts.Queries
{
    public class GetXColumnQuery : IGetXColumnQuery
    {
        private readonly IViewRepository _repository;
        private readonly IColumnAdapter _adapter;

        public GetXColumnQuery(
            IViewRepository repository,
            IColumnAdapter adapter)
        {
            _repository = repository;
            _adapter = adapter;
        }

        public ColumnDto Query()
        {
            var scatterPlot = _repository.Get<ScatterPlot>();

            var layout = scatterPlot.GetLayout();

            var column = layout.XAxisColumn;

            var columnDto = _adapter.Adapt(column);

            return columnDto;
        }
    }
}
