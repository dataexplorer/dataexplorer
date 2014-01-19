using System;
using DataExplorer.Application.Core.Commands;
using DataExplorer.Application.Filters.Commands;

namespace DataExplorer.Presentation.Panes.Filter
{
    public abstract class FilterViewModel
    {
        private readonly Domain.Filters.Filter _filter;
        protected readonly ICommandBus _commandBus;

        protected FilterViewModel(Domain.Filters.Filter filter, ICommandBus commandBus)
        {
            _filter = filter;
            _commandBus = commandBus;
        }

        public Domain.Filters.Filter Filter
        {
            get { return _filter; }
        }

        public string Label
        {
            get { return _filter.Column.Name; }
        }

        public bool IsIncludeNullVisible
        {
            get { return _filter.Column.HasNulls; }
        }

        public bool IncludeNull
        {
            get { return _filter.IncludeNull; }
            set
            {
                _filter.IncludeNull = value;
                _commandBus.Execute(new UpdateFilterCommand(_filter));
            }
        }
    }
}
