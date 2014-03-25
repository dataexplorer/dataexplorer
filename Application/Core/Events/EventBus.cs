using System;
using System.Collections.Generic;
using System.Linq;
using Ninject;

namespace DataExplorer.Application.Core.Events
{
    public class EventBus : IEventBus
    {
        public static IKernel Kernel;
        private readonly IEventLogger _logger;

        public EventBus(IEventLogger logger)
        {
            _logger = logger;
        }

        public void Raise(IEvent @event)
        {
            try
            {
                _logger.LogRaised(@event);

                var handlerType = typeof(IEventHandler<>)
                    .MakeGenericType(@event.GetType());

                dynamic handlers = Kernel.GetAll(handlerType);

                foreach (var handler in handlers)
                    handler.Handle((dynamic)@event);

                _logger.LogHandled(@event);
            }
            catch (Exception ex)
            {
                _logger.LogException(ex);

                // TODO: Need to display error
            }
        }
    }
}
