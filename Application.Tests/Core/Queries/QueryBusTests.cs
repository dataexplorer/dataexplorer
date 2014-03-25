using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Core.Queries;
using Moq;
using Ninject;
using NUnit.Framework;

namespace DataExplorer.Application.Tests.Core.Queries
{
    [TestFixture]
    public class QueryBusTests
    {
        private QueryBus _bus;
        private IKernel _kernel;
        private Mock<IQueryLogger> _mockLogger;
        private FakeQueryHandler _handler;
        private FakeQuery _query;

        [SetUp]
        public void SetUp()
        {
            _query = new FakeQuery();
            _handler = new FakeQueryHandler();

            _kernel = new StandardKernel();
            _kernel.Bind<IQueryHandler<FakeQuery, bool>>()
                .ToConstant(_handler);

            _mockLogger = new Mock<IQueryLogger>();

            _bus = new QueryBus(_mockLogger.Object);

            QueryBus.Kernel = _kernel;
        }

        [Test]
        public void TestExecuteShouldLogExecutingMessage()
        {
            _bus.Execute(_query);
            _mockLogger.Verify(p => p.LogExecuting(_query), Times.Once());
        }

        [Test]
        public void TestExecuteShouldExecuteQuery()
        {
            _bus.Execute(_query);
            Assert.That(_handler.WasExecuted, Is.True);
        }

        [Test]
        public void TestExecuteShouldLogExecutedMessage()
        {
            _bus.Execute(_query);
            _mockLogger.Verify(p => p.LogExecuting(_query), Times.Once());
        }
    }
}
