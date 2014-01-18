using DataExplorer.Application.Core.Events;
using DataExplorer.Domain.Filters;

namespace DataExplorer.Application.Filters.Events
{
    public class FilterAddedEvent : FilterEvent
    {
        public FilterAddedEvent(Filter filter) : base(filter)
        {
        }
    }
}
