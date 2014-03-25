using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Core.Logs;

namespace DataExplorer.Application.Core.Events
{
    public class EventLogger : IEventLogger
    {
        private const string RaisedTemplate = "{0} was raised.";
        private const string HandledTemplate = "{0} was handled.";

        private readonly ILog _log;

        public EventLogger(ILog log)
        {
            _log = log;
        }

        public void LogRaised(IEvent @event)
        {
            var eventName = ParseEventName(@event.GetType().Name);

            _log.Debug(string.Format(RaisedTemplate, eventName));
        }

        public void LogHandled(IEvent @event)
        {
            var eventName = ParseEventName(@event.GetType().Name);

            _log.Debug(string.Format(HandledTemplate, eventName));
        }

        private string ParseEventName(string name)
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
