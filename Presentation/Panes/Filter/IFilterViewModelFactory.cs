using System;

namespace DataExplorer.Presentation.Panes.Filter
{
    public interface IFilterViewModelFactory
    {
        FilterViewModel Create(Domain.Filters.Filter filter);
    }
}
