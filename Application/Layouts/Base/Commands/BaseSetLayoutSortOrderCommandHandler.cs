using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Columns;
using DataExplorer.Application.Core.Events;
using DataExplorer.Application.Layouts.General.Events;
using DataExplorer.Application.Views;
using DataExplorer.Domain.Layouts;
using DataExplorer.Domain.Views.ScatterPlots;

namespace DataExplorer.Application.Layouts.Base.Commands
{
    public class BaseSetLayoutSortOrderCommandHandler
    {
        private readonly IViewRepository _repository;
        private readonly IEventBus _eventBus;

         public BaseSetLayoutSortOrderCommandHandler( 
            IViewRepository repository, 
            IEventBus eventBus)
        {
            _repository = repository;
            _eventBus = eventBus;
        }

        public void Execute(Action<ScatterPlotLayout, SortOrder> setColumnAction, SortOrder sortOrder)
        {
            var view = _repository.Get<ScatterPlot>();

            var layout = view.GetLayout();

            setColumnAction(layout, sortOrder);

            _eventBus.Raise(new LayoutChangedEvent());
        }
    }
}
