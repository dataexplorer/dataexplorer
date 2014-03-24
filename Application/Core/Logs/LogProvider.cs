using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataExplorer.Application.Core.Logs
{
    public class LogProvider : ILogProvider
    {
        private const string LogFileExtension = ".txt";

        private readonly ILogFolder _logFolder;
        private readonly ILogFile _logFile;

        public LogProvider(
            ILogFolder logFolder,
            ILogFile logFile)
        {
            _logFolder = logFolder;
            _logFile = logFile;
        }

        public void CreateLogRepository()
        {
            var folderPath = _logFolder.GetLogFolder();

            _logFolder.CreateFolder(folderPath);
        }

        public void WriteLog(DateTime dateTime, int threadId, LogLevel level, string message)
        {
            var path = GetFilePath(dateTime);

            var text = Write(dateTime, threadId, level, message);

            _logFile.Write(path, text);
        }

        private string GetFilePath(DateTime dateTime)
        {
            return new StringBuilder()
                .Append(_logFolder.GetLogFolder())
                .Append(Path.DirectorySeparatorChar)
                .Append(dateTime.ToUniversalTime().ToString("yyyy-MM-dd"))
                .Append(LogFileExtension)
                .ToString();
        }

        public string Write(DateTime dateTime, int threadId, LogLevel level, string message)
        {
            return new StringBuilder()
                .Append(dateTime.ToUniversalTime().ToString("u"))
                .Append(" ")
                .AppendFormat("[{0}]", threadId)
                .Append(" ")
                .Append(level.ToString().ToUpper())
                .Append(" - ")
                .Append(message)
                .Append(Environment.NewLine)
                .ToString();
        }
    }
}
