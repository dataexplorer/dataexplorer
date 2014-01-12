using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Events;

namespace DataExplorer.Tests.Domain.Events
{
    public class FakeDomainEventDomainHandler : IDomainHandler<FakeDomainEvent>
    {
        private bool _wasHandled;

        public bool WasHandled
        {
            get { return _wasHandled; }
        }

        public void Handle(FakeDomainEvent args)
        {
            _wasHandled = true;
        }
    }
}
