using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Core.Commands;
using DataExplorer.Application.Core.Logs;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Application.Tests.Core.Commands
{
    [TestFixture]
    public class CommandLoggerTests
    {
        private CommandLogger _logger;
        private Mock<ILog> _mockLog;

        [SetUp]
        public void SetUp()
        {
            _mockLog = new Mock<ILog>();

            _logger = new CommandLogger(_mockLog.Object);
        }

        [Test]
        public void TestLogExecutingShouldLogInfo()
        {
            _logger.LogExecuting(new FakeCommand());
            _mockLog.Verify(p => p.Info("Fake Command is executing."), Times.Once());
        }

        [Test]
        public void TestLogExecutedShouldLogInfo()
        {
            _logger.LogExecuted(new FakeCommand());
            _mockLog.Verify(p => p.Info("Fake Command was executed."), Times.Once());
        }

        [Test]
        public void TestLogExceptionShouldLogError()
        {
            var ex = new Exception();
            _logger.LogException(ex);
            _mockLog.Verify(p => p.Error(ex), Times.Once());
        }
    }
}
