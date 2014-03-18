using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Core.Events;
using DataExplorer.Application.Layouts.General.Events;
using DataExplorer.Application.Views;
using DataExplorer.Domain.Views.ScatterPlots;

namespace DataExplorer.Application.Layouts.Base.Commands
{
    public abstract class BaseUnsetLayoutColumnCommandHandler
    {
        private readonly IViewRepository _viewRepository;
        private readonly IEventBus _eventBus;

        public BaseUnsetLayoutColumnCommandHandler(
            IViewRepository viewRepository,
            IEventBus eventBus)
        {
            _viewRepository = viewRepository;
            _eventBus = eventBus;
        }

        public void Execute(Action<ScatterPlotLayout> unsetColumnAction)
        {
            var scatterPlot = _viewRepository.Get<ScatterPlot>();

            var layout = scatterPlot.GetLayout();

            unsetColumnAction(layout);

            _eventBus.Raise(new LayoutChangedEvent());
        }
    }
}
