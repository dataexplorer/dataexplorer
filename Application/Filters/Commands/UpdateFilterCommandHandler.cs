using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Core.Commands;
using DataExplorer.Application.Core.Events;
using DataExplorer.Application.Filters.Events;
using DataExplorer.Domain.Filters;

namespace DataExplorer.Application.Filters.Commands
{
    public class UpdateFilterCommandHandler : ICommandHandler<UpdateFilterCommand>
    {
        private readonly IEventBus _eventBus;

        public UpdateFilterCommandHandler(IEventBus eventBus)
        {
            _eventBus = eventBus;
        }

        public void Execute(UpdateFilterCommand command)
        {
            // NOTE: There is now work to do here since we're
            // NOTE: directly updating the domain object (no DTO)
            
            _eventBus.Raise(new FilterChangedEvent(command.Filter));
        }
    }
}
