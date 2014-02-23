using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Columns;
using DataExplorer.Application.Core.Queries;
using DataExplorer.Application.Views;
using DataExplorer.Domain.Views.ScatterPlots;

namespace DataExplorer.Application.Layouts.Size.Queries
{
    public class GetSizeColumnQueryHandler 
        : IQueryHandler<GetSizeColumnQuery, ColumnDto>
    {
        private readonly IViewRepository _repository;
        private readonly IColumnAdapter _adapter;

        public GetSizeColumnQueryHandler(
            IViewRepository repository, 
            IColumnAdapter adapter)
        {
            _repository = repository;
            _adapter = adapter;
        }

        public ColumnDto Execute(GetSizeColumnQuery getSizeColumnQuery)
        {
            var scatterPlot = _repository.Get<ScatterPlot>();

            var layout = scatterPlot.GetLayout();

            var column = layout.SizeColumn;

            var columnDto = _adapter.Adapt(column);

            return columnDto;
        }
    }
}
