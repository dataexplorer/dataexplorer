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
    public class SetUpperSizeCommandHandler 
        : ICommandHandler<SetUpperSizeCommand>
    {
        private readonly IViewRepository _repository;
        private readonly IEventBus _eventBus;

        public SetUpperSizeCommandHandler(
            IViewRepository repository, 
            IEventBus eventBus)
        {
            _repository = repository;
            _eventBus = eventBus;
        }

        public void Execute(SetUpperSizeCommand command)
        {
            var scatterPlot = _repository.Get<ScatterPlot>();

            var layout = scatterPlot.GetLayout();

            layout.UpperSize = command.Value;

            _eventBus.Raise(new LayoutChangedEvent());
        }
    }
}
