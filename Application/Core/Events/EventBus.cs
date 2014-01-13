using System;
using System.Collections.Generic;
using System.Linq;
using Ninject;

namespace DataExplorer.Application.Core.Events
{
    public class EventBus : IEventBus
    {
        public static IKernel Kernel;

        public void Raise(IEvent @event)
        {
            var handlerType = typeof(IEventHandler<>)
                .MakeGenericType(@event.GetType());

            dynamic handlers = Kernel.GetAll(handlerType);

            foreach (var handler in handlers)
                handler.Handle((dynamic) @event);
        }
    }
}
