using System;
using System.Collections.Generic;
using System.Linq;
using Ninject;

namespace DataExplorer.Application.Core.Events
{
    public class EventBus : IEventBus
    {
        public static IKernel Kernel;

        public void Raise<T>(T args) where T : IEvent
        {
            if (Kernel != null)
                foreach (var handler in Kernel.GetAll<IEventHandler<T>>())
                    handler.Handle(args);
        }
    }
}
