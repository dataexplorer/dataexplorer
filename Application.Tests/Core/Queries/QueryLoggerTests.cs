using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Core.Logs;
using DataExplorer.Application.Core.Queries;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Application.Tests.Core.Queries
{
    [TestFixture]
    public class QueryLoggerTests
    {
        private QueryLogger _logger;
        private Mock<ILog> _mockLog;

        [SetUp]
        public void SetUp()
        {
            _mockLog = new Mock<ILog>();

            _logger = new QueryLogger(_mockLog.Object);
        }

        [Test]
        public void TestLogExecutingShouldLogInfo()
        {
            _logger.LogExecuting(new FakeQuery());
            _mockLog.Verify(p => p.Debug("Fake Query is executing."), Times.Once());
        }

        [Test]
        public void TestLogExecutedShouldLogInfo()
        {
            _logger.LogExecuted(new FakeQuery());
            _mockLog.Verify(p => p.Debug("Fake Query was executed."), Times.Once());
        }
    }
}
