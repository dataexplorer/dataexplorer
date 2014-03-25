using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Core.Commands;
using DataExplorer.Application.Core.Logs;

namespace DataExplorer.Application.Core.Queries
{
    public class QueryLogger : IQueryLogger
    {
        private const string ExecutingTemplate = "{0} is executing.";
        private const string ExecutedTemplate = "{0} was executed.";

        private readonly ILog _log;

        public QueryLogger(ILog log)
        {
            _log = log;
        }

        public void LogExecuting<T>(IQuery<T> query)
        {
            var queryName = ParseQueryName(query.GetType().Name);

            _log.Debug(string.Format(ExecutingTemplate, queryName));
        }

        public void LogExecuted<T>(IQuery<T> query)
        {
            var queryName = ParseQueryName(query.GetType().Name);

            _log.Debug(string.Format(ExecutedTemplate, queryName));
        }

        public void LogException(Exception ex)
        {
            _log.Error(ex);
        }

        private string ParseQueryName(string name)
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
