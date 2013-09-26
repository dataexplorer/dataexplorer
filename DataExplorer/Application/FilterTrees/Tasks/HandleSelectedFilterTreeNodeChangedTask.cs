using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Application;
using DataExplorer.Application.Core.Events;
using DataExplorer.Application.Filters;
using DataExplorer.Domain.Filters;

namespace DataExplorer.Application.FilterTrees.Tasks
{
    public class HandleSelectedFilterTreeNodeChangedTask : IHandleSelectedFilterTreeNodeChangedTask
    {
        private readonly IFilterRepository _repository;
        private readonly IApplicationStateService _service;

        public HandleSelectedFilterTreeNodeChangedTask(
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
