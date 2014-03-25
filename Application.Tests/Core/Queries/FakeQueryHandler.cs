using System;
using DataExplorer.Application.Core.Queries;

namespace DataExplorer.Application.Tests.Core.Queries
{
    public class FakeQueryHandler
        : IQueryHandler<FakeQuery, bool>
    {
        public bool ThrowException;
        public bool WasExecuted;

        public bool Execute(FakeQuery command)
        {
            if (ThrowException)
                throw new Exception();

            WasExecuted = true;

            return true;
        }
    }
}