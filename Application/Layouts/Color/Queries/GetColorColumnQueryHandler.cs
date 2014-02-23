using System;
using DataExplorer.Application.Columns;
using DataExplorer.Application.Core.Queries;
using DataExplorer.Application.Views;
using DataExplorer.Domain.Views.ScatterPlots;

namespace DataExplorer.Application.Layouts.Color.Queries
{
    public class GetColorColumnQueryHandler : IQueryHandler<GetColorColumnQuery, ColumnDto>
    {
        private readonly IViewRepository _repository;
        private readonly IColumnAdapter _adapter;

        public GetColorColumnQueryHandler(
            IViewRepository repository, 
            IColumnAdapter adapter)
        {
            _repository = repository;
            _adapter = adapter;
        }

        public ColumnDto Execute(GetColorColumnQuery query)
        {
            var scatterPlot = _repository.Get<ScatterPlot>();

            var layout = scatterPlot.GetLayout();

            var column = layout.ColorColumn;

            var columnDto = _adapter.Adapt(column);

            return columnDto;
        }
    }
}
