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
        TResult Execute<TQuery, TResult>(TQuery query) where TQuery : IQuery<TResult>;

        void Execute<T>(T command) where T : ICommand;

        void Raise<T>(T @event) where T : IEvent;
    }
}
