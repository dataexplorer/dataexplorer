using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Core.Commands;
using DataExplorer.Application.Core.Events;
using DataExplorer.Application.Layouts.General.Events;
using DataExplorer.Application.Views;
using DataExplorer.Domain.Views.ScatterPlots;

namespace DataExplorer.Application.Layouts.Size.Commands
{
    public class UnsetSizeColumnCommandHandler 
        : ICommandHandler<UnsetSizeColumnCommand>
    {
        private readonly IViewRepository _viewRepository;
        private readonly IEventBus _eventBus;

        public UnsetSizeColumnCommandHandler(
            IViewRepository viewRepository, 
            IEventBus eventBus)
        {
            _viewRepository = viewRepository;
            _eventBus = eventBus;
        }

        public void Execute(UnsetSizeColumnCommand command)
        {
            var scatterPlot = _viewRepository.Get<ScatterPlot>();

            var layout = scatterPlot.GetLayout();

            layout.SizeColumn = null;

            _eventBus.Raise(new LayoutChangedEvent());
        }
    }
}
