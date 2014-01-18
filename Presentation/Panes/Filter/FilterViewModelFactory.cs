using System;
using DataExplorer.Domain.Filters.BooleanFilters;
using DataExplorer.Presentation.Panes.Filter.BooleanFilters;

namespace DataExplorer.Presentation.Panes.Filter
{
    public class FilterViewModelFactory : IFilterViewModelFactory
    {
        public FilterViewModel Create(Domain.Filters.Filter filter)
        {
            if (filter is BooleanFilter)
                return new BooleanFilterViewModel((BooleanFilter) filter);

            throw new ArgumentException("Filter view model could not be created because filter type not valid.");
        }
    }
}
