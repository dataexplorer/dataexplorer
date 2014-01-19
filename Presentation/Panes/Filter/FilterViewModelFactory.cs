using System;
using DataExplorer.Application.Core.Commands;
using DataExplorer.Domain.Filters;
using DataExplorer.Presentation.Panes.Filter.BooleanFilters;

namespace DataExplorer.Presentation.Panes.Filter
{
    public class FilterViewModelFactory : IFilterViewModelFactory
    {
        private readonly ICommandBus _commandBus;

        public FilterViewModelFactory(ICommandBus commandBus)
        {
            _commandBus = commandBus;
        }

        public FilterViewModel Create(Domain.Filters.Filter filter)
        {
            if (filter is BooleanFilter)
                return new BooleanFilterViewModel((BooleanFilter) filter, _commandBus);

            throw new ArgumentException("Filter view model could not be created because filter type not valid.");
        }
    }
}
