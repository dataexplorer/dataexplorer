using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Columns;
using DataExplorer.Application.Views;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Views.ScatterPlots;

namespace DataExplorer.Application.Layouts
{
    public abstract class BaseGetLayoutColumnQueryHandler
    {
        private readonly IViewRepository _repository;
        private readonly IColumnAdapter _adapter;

        protected BaseGetLayoutColumnQueryHandler(
            IViewRepository repository,
            IColumnAdapter adapter)
        {
            _repository = repository;
            _adapter = adapter;
        }

        public ColumnDto Execute(Func<ScatterPlotLayout, Column> getLayoutColumnAction)
        {
            var scatterPlot = _repository.Get<ScatterPlot>();

            var layout = scatterPlot.GetLayout();

            var column = getLayoutColumnAction(layout);

            var columnDto = _adapter.Adapt(column);

            return columnDto;
        }
    }
}
