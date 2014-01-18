using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Core.Events;
using DataExplorer.Domain.Filters;

namespace DataExplorer.Application.Filters.Events
{
    public class FilterEvent : IEvent
    {
        private readonly Filter _filter;

        public FilterEvent(Filter filter)
        {
            _filter = filter;
        }

        public Filter Filter
        {
            get { return _filter; }
        }
    }
}
