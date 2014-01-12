using System;
using System.Collections.Generic;
using System.Linq;
using Ninject;

namespace DataExplorer.Application.Core.Events
{
    public class EventBus : IEventBus
    {
        public static IKernel Kernel;

        public void Raise<T>(T @event) where T : IEvent
        {
            var handlers = Kernel.GetAll<IEventHandler<T>>();

            foreach (var handler in handlers)
                handler.Handle(@event);
        }
    }
}
