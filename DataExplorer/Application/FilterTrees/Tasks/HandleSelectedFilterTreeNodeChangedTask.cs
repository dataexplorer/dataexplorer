using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Events;
using DataExplorer.Application.Filters;
using DataExplorer.Domain.Filters;

namespace DataExplorer.Application.FilterTrees.Tasks
{
    public class HandleSelectedFilterTreeNodeChangedTask : IHandleSelectedFilterTreeNodeChangedTask
    {
        private readonly IFilterRepository _repository;

        public HandleSelectedFilterTreeNodeChangedTask(
            IFilterRepository repository)
        {
            _repository = repository;
        }

        public void Handle(SelectedFilterTreeNodeChangedEvent @event)
        {
            // TODO: Handle no selected filter case???

            // TODO remove previous filter

            var filter = @event.Node.CreateFilter();

            _repository.Add(filter);

            AppEvents.Raise(new FilterChangedEvent());
        }
    }
}
