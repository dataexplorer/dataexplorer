using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Application.Events;
using DataExplorer.Application.Core.Commands;
using DataExplorer.Application.Core.Events;

namespace DataExplorer.Application.Application.Commands
{
    public class ShowPaneCommandHandler : ICommandHandler<ShowPaneCommand>
    {
        private readonly IEventBus _eventBus;

        public ShowPaneCommandHandler(IEventBus eventBus)
        {
            _eventBus = eventBus;
        }

        public void Execute(ShowPaneCommand command)
        {
            _eventBus.Raise(new PaneVisibilityChangedEvent(command.Pane, true));
        }
    }
}
