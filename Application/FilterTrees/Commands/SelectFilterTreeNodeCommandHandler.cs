using DataExplorer.Application.Application;
using DataExplorer.Application.Core.Commands;
using DataExplorer.Application.Core.Events;
using DataExplorer.Application.Filters.Events;
using DataExplorer.Domain.FilterTrees;
using DataExplorer.Domain.Filters;

namespace DataExplorer.Application.FilterTrees.Commands
{
    public class SelectFilterTreeNodeCommandHandler 
        : ICommandHandler<SelectFilterTreeNodeCommand>
    {
        private readonly IFilterRepository _repository;
        private readonly IApplicationStateService _service;
        private readonly IEventBus _eventBus;

        public SelectFilterTreeNodeCommandHandler(
            IFilterRepository repository, 
            IApplicationStateService service, 
            IEventBus eventBus)
        {
            _repository = repository;
            _service = service;
            _eventBus = eventBus;
        }

        public void Execute(SelectFilterTreeNodeCommand command)
        {
            var previousFilter = _service.GetSelectedFilter();

            _repository.Remove(previousFilter);

            var filter = command.Entity.CreateFilter();

            _service.SetSelectedFilter(filter);

            _repository.Add(filter);

            _eventBus.Raise(new FilterChangedEvent());
        }
    }
}
