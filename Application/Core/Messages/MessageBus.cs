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
    public class MessageBus
    {
        private readonly ICommandBus _commandBus;
        private readonly IQueryBus _queryBus;
        private readonly IEventBus _eventBus;

        public MessageBus(
            ICommandBus commandBus, 
            IQueryBus queryBus, 
            IEventBus eventBus)
        {
            _commandBus = commandBus;
            _queryBus = queryBus;
            _eventBus = eventBus;
        }
        
        public void Execute(ICommand command)
        {
            _commandBus.Execute(command);   
        }

        public T Execute<T>(IQuery<T> query)
        {
            return _queryBus.Execute(query);
        }

        public void Raise(IEvent @event)
        {
            _eventBus.Raise(@event);
        }
    }
}
