using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Views;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Layouts;
using DataExplorer.Domain.Views.ScatterPlots;

namespace DataExplorer.Application.Layouts.Base.Queries
{
    public abstract class BaseGetLayoutSortOrderQueryHandler
    {
        private readonly IViewRepository _repository;
        
        protected BaseGetLayoutSortOrderQueryHandler(
            IViewRepository repository)
        {
            _repository = repository;
        }

        public SortOrder Execute(Func<ScatterPlotLayout, SortOrder> getSortOrderAction)
        {
            var scatterPlot = _repository.Get<ScatterPlot>();

            var layout = scatterPlot.GetLayout();

            var sortOrder = getSortOrderAction(layout);

            return sortOrder;
        }
    }
}
