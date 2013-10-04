using DataExplorer.Application.Application;
using DataExplorer.Application.Core.Events;
using DataExplorer.Application.Filters;
using DataExplorer.Application.Filters.Events;
using DataExplorer.Domain.Filters;

namespace DataExplorer.Application.FilterTrees.Events
{
    public class SelectedFilterTreeNodeChangedEventHandler : ISelectedFilterTreeNodeChangedEventHandler
    {
        private readonly IFilterRepository _repository;
        private readonly IApplicationStateService _service;

        public SelectedFilterTreeNodeChangedEventHandler(
            IFilterRepository repository,
            IApplicationStateService service)
        {
            _repository = repository;
            _service = service;
        }

        public void Handle(SelectedFilterTreeNodeChangedEvent @event)
        {
            var previousFilter = _service.SelectedFilter;

            _repository.Remove(previousFilter);

            var filter = @event.Node.CreateFilter();

            _service.SelectedFilter = filter;
            
            _repository.Add(filter);

            AppEvents.Raise(new FilterChangedEvent());
        }
    }
}
