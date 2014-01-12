using DataExplorer.Application.Core.Commands;

namespace DataExplorer.Application.Tests.Core.Commands
{
    public class FakeCommandHandler
        : ICommandHandler<FakeCommand>
    {
        public bool WasExecuted;

        public void Execute(FakeCommand command)
        {
            WasExecuted = true;
        }
    }
}