using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Core.Events;
using DataExplorer.Application.Core.Logs;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Application.Tests.Core.Events
{
    [TestFixture]
    public class EventLoggerTests
    {
        private EventLogger _logger;
        private Mock<ILog> _mockLog;

        [SetUp]
        public void SetUp()
        {
            _mockLog = new Mock<ILog>();

            _logger = new EventLogger(_mockLog.Object);
        }

        [Test]
        public void TestLogExecutingShouldLogInfo()
        {
            _logger.LogRaised(new FakeEvent());
            _mockLog.Verify(p => p.Debug("Fake Event was raised."), Times.Once());
        }

        [Test]
        public void TestLogExecutedShouldLogInfo()
        {
            _logger.LogHandled(new FakeEvent());
            _mockLog.Verify(p => p.Debug("Fake Event was handled."), Times.Once());
        }
    }
}
