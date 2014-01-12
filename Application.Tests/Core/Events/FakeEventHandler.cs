using DataExplorer.Application.Core.Events;

namespace DataExplorer.Application.Tests.Core.Events
{
    public class FakeEventHandler
        : IEventHandler<FakeEvent>
    {
        public bool WasRaised;

        public void Handle(FakeEvent args)
        {
            WasRaised = true;
        }
    }
}