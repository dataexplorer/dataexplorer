using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Core.Commands;
using DataExplorer.Domain.Filters;

namespace DataExplorer.Presentation.Panes.Filter.NullFilters
{
    public class NullFilterViewModel : FilterViewModel
    {
        public NullFilterViewModel(ICommandBus commandBus, NullFilter filter)
            : base(commandBus, filter)
        {
        }
    }
}
