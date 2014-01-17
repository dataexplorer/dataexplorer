using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Filters.BooleanFilters;

namespace DataExplorer.Presentation.Panes.Filter.BooleanFilters
{
    public class BooleanFilterViewModel
    {
        private readonly BooleanFilter _filter;

        public BooleanFilterViewModel(BooleanFilter filter)
        {
            _filter = filter;
        }


    }
}
