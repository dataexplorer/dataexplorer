using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Application;
using DataExplorer.Application.Core.Commands;
using DataExplorer.Application.Core.Events;
using DataExplorer.Application.Filters.Events;

namespace DataExplorer.Application.Filters.Commands
{
    public class RemoveFilterCommandHandler : ICommandHandler<RemoveFilterCommand>
    {
        private readonly IApplicationStateService _stateService;
        private readonly IFilterRepository _repository;
        private readonly IEventBus _eventBus;

        public RemoveFilterCommandHandler(
            IApplicationStateService stateService,
            IFilterRepository repository,
            IEventBus eventBus)
        {
            _stateService = stateService;
            _repository = repository;
            _eventBus = eventBus;
        }

        public void Execute(RemoveFilterCommand command)
        {
            var filter = command.Filter;

            if (_stateService.GetSelectedFilter() == filter)
                _stateService.SetSelectedFilter(null);

            _repository.Remove(filter);

            _eventBus.Raise(new FilterRemovedEvent(filter));
        }
    }
}
