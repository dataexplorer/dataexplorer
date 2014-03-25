using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataExplorer.Application.Core.Events
{
    public interface IEventLogger
    {
        void LogRaised(IEvent @event);

        void LogHandled(IEvent @event);

        void LogException(Exception ex);
    }
}
