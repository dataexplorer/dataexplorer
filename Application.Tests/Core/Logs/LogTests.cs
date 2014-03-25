using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Core.Logs;
using DataExplorer.Application.Core.Threads;
using DataExplorer.Application.Core.Time;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Application.Tests.Core.Logs
{
    [TestFixture]
    public class LogTests
    {
        private Log _log;
        private Mock<IDateTimeService> _mockDateTimeService;
        private Mock<IThreadService> _mockThreadService;
        private Mock<ILogProvider> _mockLogProvider;
        private DateTime _dateTime;
        private int _threadId;
        private string _message;
        private Exception _exception;

        [SetUp]
        public void SetUp()
        {
            _dateTime = new DateTime(2001, 2, 3);
            _threadId = 1;
            _message = "Test";
            _exception = new Exception(_message);

            _mockDateTimeService = new Mock<IDateTimeService>();
            _mockDateTimeService.Setup(p => p.GetCurrentUtcDateTime())
                .Returns(_dateTime);

            _mockThreadService = new Mock<IThreadService>();
            _mockThreadService.Setup(p => p.GetCurrentThreadId())
                .Returns(_threadId);

            _mockLogProvider = new Mock<ILogProvider>();

            _log = new Log(
                _mockDateTimeService.Object,
                _mockThreadService.Object,
                _mockLogProvider.Object);
        }

        [Test]
        public void TestDebugShouldNotLogBelowVerbosityLevel()
        {
            _log.VerbosityLevel = LogLevel.Info;
            _log.Debug(_message);
            _mockLogProvider.Verify(p => 
                p.WriteLog(_dateTime, _threadId, LogLevel.Debug, _message), 
                Times.Never());
        }

        [Test]
        public void TestDebugShouldWriteLog()
        {
            _log.VerbosityLevel = LogLevel.Debug;
            _log.Debug(_message);
            _mockLogProvider.Verify(p => 
                p.WriteLog(_dateTime, _threadId, LogLevel.Debug, _message),
                Times.Once());
        }

        [Test]
        public void TestInfoShouldWriteLog()
        {
            _log.Info(_message);
            _mockLogProvider.Verify(p => 
                p.WriteLog(_dateTime, _threadId, LogLevel.Info, _message),
                Times.Once());
        }

        [Test]
        public void TestWarningShouldWriteLog()
        {
            _log.Warning(_message);
            _mockLogProvider.Verify(p => 
                p.WriteLog(_dateTime, _threadId, LogLevel.Warn, _message), 
                Times.Once());
        }

        [Test]
        public void TestErrorShouldWriteExceptionToLog()
        {
            var message = "Test\r\nType: System.Exception\r\nSource: \r\nStack Trace:\r\n\r\n";
            _log.Error(_exception);
            _mockLogProvider.Verify(p => 
                p.WriteLog(_dateTime, _threadId, LogLevel.Error, message), 
                Times.Once());
        }

        [Test]
        public void TestFatalShouldWriteExceptionToLog()
        {
            var message = "Test\r\nType: System.Exception\r\nSource: \r\nStack Trace:\r\n\r\n";
            _log.Fatal(_exception);
            _mockLogProvider.Verify(p => 
                p.WriteLog(_dateTime, _threadId, LogLevel.Fatal, message), 
                Times.Once());
        }

        [Test]
        public void TestErrorShouldWriteInnerExceptionsToLog()
        {
            var message = "Test\r\nType: System.Exception\r\nSource: \r\nStack Trace:\r\n\r\n"
                + "Inner Exception: Test2\r\nType: System.Exception\r\nSource: \r\nStack Trace:\r\n\r\n";
            var innerException = new Exception("Test2");
            _exception = new Exception(_message, innerException);
            _log.Error(_exception);
            _mockLogProvider.Verify(p => 
                p.WriteLog(_dateTime, _threadId, LogLevel.Error, message), 
                Times.Once());
        }
    }
}
