using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataExplorer.Application.Core.Logs
{
    public interface ILogProvider
    {
        void CreateLogRepository();

        void WriteLog(DateTime dateTime, int threadId, LogLevel level, string message);
    }
}
