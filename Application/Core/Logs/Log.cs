using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Core.Threads;
using DataExplorer.Application.Core.Time;

namespace DataExplorer.Application.Core.Logs
{
    public class Log : ILog
    {
        private readonly IDateTimeService _dateTimeService;
        private readonly IThreadService _threadService;
        private readonly ILogProvider _logProvider;

        public Log(
            IDateTimeService dateTimeService,
            IThreadService threadService,
            ILogProvider logProvider)
        {
            _dateTimeService = dateTimeService;
            _threadService = threadService;
            _logProvider = logProvider;
        }

        public void Debug(string message)
        {
            LogMessage(LogLevel.Debug, message);
        }

        public void Info(string message)
        {
            LogMessage(LogLevel.Info, message);
        }

        public void Warning(string message)
        {
            LogMessage(LogLevel.Warn, message);
        }

        public void Error(Exception ex)
        {
            LogMessage(LogLevel.Error, GetExceptionText(ex));
        }

        public void Fatal(Exception ex)
        {
            LogMessage(LogLevel.Fatal, GetExceptionText(ex));
        }

        private void LogMessage(LogLevel logLevel, string message)
        {
            var dateTime = _dateTimeService.GetCurrentUtcDateTime();

            var threadId = _threadService.GetCurrentThreadId();

            _logProvider.WriteLog(dateTime, threadId, logLevel, message);
        }

        private string GetExceptionText(Exception ex)
        {
            var text = new StringBuilder()
                .AppendLine(ex.Message)
                .AppendLine("Type: " + ex.GetType().FullName)
                .AppendLine("Source: " + ex.Source)
                .AppendLine("Stack Trace:" + Environment.NewLine + ex.StackTrace);

            if (ex.InnerException != null)
                text.Append("Inner Exception: " + GetExceptionText(ex.InnerException));

            return text.ToString();
        }
    }
}
