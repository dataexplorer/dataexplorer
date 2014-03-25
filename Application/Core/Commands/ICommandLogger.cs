using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataExplorer.Application.Core.Commands
{
    public interface ICommandLogger
    {
        void LogExecuting(ICommand command);

        void LogExecuted(ICommand command);

        void LogException(Exception exception);
    }
}
