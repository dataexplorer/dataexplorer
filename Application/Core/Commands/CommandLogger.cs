using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Core.Logs;

namespace DataExplorer.Application.Core.Commands
{
    public class CommandLogger : ICommandLogger
    {
        private const string ExecutingTemplate = "{0} is executing.";
        private const string ExecutedTemplate = "{0} was executed.";

        private readonly ILog _log;

        public CommandLogger(ILog log)
        {
            _log = log;
        }

        public void LogExecuting(ICommand command)
        {
            var commandName = ParseCommandName(command.GetType().Name);

            _log.Info(string.Format(ExecutingTemplate, commandName));
        }

        public void LogExecuted(ICommand command)
        {
            var commandName = ParseCommandName(command.GetType().Name);

            _log.Info(string.Format(ExecutedTemplate, commandName));
        }

        public void LogException(Exception ex)
        {
            _log.Error(ex);
        }

        private string ParseCommandName(string name)
        {
            return string.Concat(
                name.Select(
                    p => Char.IsUpper(p)
                        ? " " + p
                        : p.ToString()))
                .TrimStart();
        }
    }
}
