using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Core.Logs;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Application.Tests.Core.Logs
{
    [TestFixture]
    public class LogProviderTestscs
    {
        private LogProvider _provider;
        private Mock<ILogFolder> _mockFolder;
        private Mock<ILogFile> _mockFile;
        private DateTime _dateTime;
        private int _threadId;
        private LogLevel _level;
        private string _message;
        private string _filePath;
        private string _text;
        private string _folderPath;

        [SetUp]
        public void SetUp()
        {
            _dateTime = DateTime.Parse("2001-02-03 00:00:00Z");
            _threadId = 1;
            _level = LogLevel.Debug;
            _message = "Test";

            _folderPath = @"C:\Logs";
            _filePath = @"C:\Logs\2001-02-03.txt";
            _text = "2001-02-03 00:00:00Z [1] DEBUG - Test\r\n";
            
            _mockFolder = new Mock<ILogFolder>();
            _mockFolder.Setup(p => p.GetLogFolder())
                .Returns(_folderPath);

            _mockFile = new Mock<ILogFile>();

            _provider = new LogProvider(
                _mockFolder.Object,
                _mockFile.Object);
        }

        [Test]
        public void TestCreateLogRepositoryShouldCreateLogsFolder()
        {
            _provider.CreateLogRepository();
            _mockFolder.Verify(p => p.CreateFolder(_folderPath));
        }

        [Test]
        public void TestWriteLogShouldWriteLogToFile()
        {
            _provider.WriteLog(_dateTime, _threadId, _level, _message);
            _mockFile.Verify(p => p.Write(_filePath, _text));
        }
    }
}
