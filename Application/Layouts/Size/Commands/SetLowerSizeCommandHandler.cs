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
    public class SetLowerSizeCommandHandler
        : ICommandHandler<SetLowerSizeCommand>
    {
        private readonly IViewRepository _repository;
        private readonly IEventBus _eventBus;

        public SetLowerSizeCommandHandler(
            IViewRepository repository, 
            IEventBus eventBus)
        {
            _repository = repository;
            _eventBus = eventBus;
        }

        public void Execute(SetLowerSizeCommand command)
        {
            var scatterPlot = _repository.Get<ScatterPlot>();

            var layout = scatterPlot.GetLayout();

            layout.LowerSize = command.Value;

            _eventBus.Raise(new LayoutChangedEvent());
        }
    }
}
