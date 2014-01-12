using DataExplorer.Application.Core.Queries;

namespace DataExplorer.Application.Tests.Core.Queries
{
    public class FakeQueryHandler
        : IQueryHandler<FakeQuery, bool>
    {
        public bool WasExecuted;

        public bool Execute(FakeQuery command)
        {
            WasExecuted = true;

            return true;
        }
    }
}