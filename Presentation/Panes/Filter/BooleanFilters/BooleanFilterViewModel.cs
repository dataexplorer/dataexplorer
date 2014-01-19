using System;
using DataExplorer.Application.Core.Commands;
using DataExplorer.Application.Filters.Commands;
using DataExplorer.Domain.Filters;

namespace DataExplorer.Presentation.Panes.Filter.BooleanFilters
{
    public class BooleanFilterViewModel : FilterViewModel
    {
        private readonly BooleanFilter _filter;

        public BooleanFilterViewModel(BooleanFilter filter, ICommandBus commandBus) : base(filter, commandBus)
        {
            _filter = filter;
        }

        public bool IncludeTrue
        {
            get { return _filter.IncludeTrue; }
            set
            {
                _filter.IncludeTrue = value;
                _commandBus.Execute(new UpdateFilterCommand(_filter));
            }
        }

        public bool IncludeFalse
        {
            get { return _filter.IncludeFalse; }
            set
            {
                _filter.IncludeFalse = value;
                _commandBus.Execute(new UpdateFilterCommand(_filter));
            }
        }
    }
}
