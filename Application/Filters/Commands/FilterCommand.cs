using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Core.Commands;
using DataExplorer.Domain.Filters;

namespace DataExplorer.Application.Filters.Commands
{
    public class FilterCommand : ICommand
    {
        private readonly Filter _filter;

        public FilterCommand(Filter filter)
        {
            _filter = filter;
        }

        public Filter Filter
        {
            get { return _filter; }
        }
    }
}
