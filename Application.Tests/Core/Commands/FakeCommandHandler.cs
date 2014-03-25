using System;
using DataExplorer.Application.Core.Commands;

namespace DataExplorer.Application.Tests.Core.Commands
{
    public class FakeCommandHandler
        : ICommandHandler<FakeCommand>
    {
        public bool ThrowException;
        public bool WasExecuted;

        public void Execute(FakeCommand command)
        {
            if (ThrowException)
                throw new Exception();

            WasExecuted = true;
        }
    }
}