using DataExplorer.Application.Application;
using DataExplorer.Application.Core.Events;
using DataExplorer.Application.Filters.Events;
using DataExplorer.Domain.FilterTrees;
using DataExplorer.Domain.Filters;

namespace DataExplorer.Application.FilterTrees.Commands
{
    public class SelectFilterTreeNodeCommand : ISelectFilterTreeNodeCommand
    {
        private readonly IFilterRepository _repository;
        private readonly IApplicationStateService _service;
        private readonly IEventBus _eventBus;

        public SelectFilterTreeNodeCommand(
            IFilterRepository repository, 
            IApplicationStateService service, 
            IEventBus eventBus)
        {
            _repository = repository;
            _service = service;
            _eventBus = eventBus;
        }

        public void Execute(FilterTreeNode node)
        {
            var previousFilter = _service.GetSelectedFilter();

            _repository.Remove(previousFilter);

            var filter = node.CreateFilter();

            _service.SetSelectedFilter(filter);
            
            _repository.Add(filter);

            _eventBus.Raise(new FilterChangedEvent());
        }
    }
}
