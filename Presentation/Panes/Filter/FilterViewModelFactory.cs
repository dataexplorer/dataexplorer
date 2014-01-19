using System;
using DataExplorer.Application.Core.Commands;
using DataExplorer.Domain.Filters;
using DataExplorer.Presentation.Panes.Filter.BooleanFilters;
using DataExplorer.Presentation.Panes.Filter.DateTimeFilters;
using DataExplorer.Presentation.Panes.Filter.FloatFilters;
using DataExplorer.Presentation.Panes.Filter.IntegerFilters;
using DataExplorer.Presentation.Panes.Filter.StringFilters;

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
                return new BooleanFilterViewModel(_commandBus, (BooleanFilter) filter);

            if (filter is DateTimeFilter)
                return new DateRangeFilterViewModel(_commandBus, (DateTimeFilter) filter);

            if (filter is FloatFilter)
                return new FloatRangeFilterViewModel(_commandBus, (FloatFilter) filter);

            if (filter is IntegerFilter)
                return new IntegerRangeFilterViewModel(_commandBus, (IntegerFilter) filter);

            if (filter is StringFilter)
                return new StringFilterViewModel(_commandBus, (StringFilter) filter);

            throw new ArgumentException("Filter view model could not be created because filter type not valid.");
        }
    }
}
