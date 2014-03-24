using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataExplorer.Application.Core.Logs
{
    public interface ILog
    {
        void Debug(string message);

        void Info(string message);

        void Warning(string message);

        void Error(Exception ex);

        void Fatal(Exception ex);
    }
}
