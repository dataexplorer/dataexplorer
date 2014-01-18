using System;

namespace DataExplorer.Presentation.Panes.Filter
{
    public abstract class FilterViewModel
    {
        private readonly Domain.Filters.Filter _filter;

        protected FilterViewModel(Domain.Filters.Filter filter)
        {
            _filter = filter;
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
            set { _filter.IncludeNull = value; }
        }
    }
}
