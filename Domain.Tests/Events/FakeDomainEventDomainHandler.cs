using DataExplorer.Domain.Events;

namespace DataExplorer.Domain.Tests.Events
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
