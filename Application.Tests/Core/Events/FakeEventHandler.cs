using System;
using System.Data.Odbc;
using DataExplorer.Application.Core.Events;

namespace DataExplorer.Application.Tests.Core.Events
{
    public class FakeEventHandler
        : IEventHandler<FakeEvent>
    {
        public bool ThrowException;
        public bool WasRaised;

        public void Handle(FakeEvent args)
        {
            if (ThrowException)
                throw new Exception();

            WasRaised = true;
        }
    }
}