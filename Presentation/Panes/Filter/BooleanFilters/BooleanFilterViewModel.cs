using System;
using DataExplorer.Domain.Filters;

namespace DataExplorer.Presentation.Panes.Filter.BooleanFilters
{
    public class BooleanFilterViewModel : FilterViewModel
    {
        private readonly BooleanFilter _filter;

        public BooleanFilterViewModel(BooleanFilter filter) : base(filter)
        {
            _filter = filter;
        }

        public bool IncludeTrue
        {
            get { return _filter.IncludeTrue; }
            set { _filter.IncludeTrue = value; }
        }

        public bool IncludeFalse
        {
            get { return _filter.IncludeFalse; }
            set { _filter.IncludeFalse = value; }
        }
    }
}
