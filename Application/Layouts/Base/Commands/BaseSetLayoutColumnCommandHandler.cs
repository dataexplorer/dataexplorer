using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Columns;
using DataExplorer.Application.Core.Events;
using DataExplorer.Application.Layouts.General.Events;
using DataExplorer.Application.Views;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Views.ScatterPlots;

namespace DataExplorer.Application.Layouts.Base.Commands
{
    public abstract class BaseSetLayoutColumnCommandHandler
    {
        private readonly IColumnRepository _columnRepository;
        private readonly IViewRepository _viewRepository;
        private readonly IEventBus _eventBus;

        public BaseSetLayoutColumnCommandHandler(
            IColumnRepository columnRepository, 
            IViewRepository viewRepository, 
            IEventBus eventBus)
        {
            _columnRepository = columnRepository;
            _viewRepository = viewRepository;
            _eventBus = eventBus;
        }

        public void Execute(int id, Action<ScatterPlotLayout, Column> setColumnAction)
        {
            var column = _columnRepository.Get(id);

            var scatterPlot = _viewRepository.Get<ScatterPlot>();

            var layout = scatterPlot.GetLayout();

            setColumnAction(layout, column);

            _eventBus.Raise(new LayoutChangedEvent());
        }
    }
}
