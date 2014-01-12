using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Core.Commands;
using DataExplorer.Application.Core.Events;
using DataExplorer.Application.Core.Queries;

namespace DataExplorer.Application.Core.Messages
{
    public interface IMessageBus
    {
        void Execute(ICommand command);

        T Execute<T>(IQuery<T> query);

        void Raise(IEvent @event);
    }
}
