using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;

namespace DataExplorer.Domain.Events
{
    public static class DomainEvents
    {
        public static IKernel Kernel;
        
        //[ThreadStatic]
        private static List<Delegate> _handlers;

        public static void Register<T>(Action<T> handler) where T : IDomainEvent
        {
            if (_handlers == null)
                _handlers = new List<Delegate>();

            _handlers.Add(handler);
        }

        public static void Raise<T>(T args) where T : IDomainEvent
        {
            if (Kernel != null)
                foreach (var handler in Kernel.GetAll<IHandler<T>>())
                    handler.Handle(args);
            
            if (_handlers != null)
                foreach (var handler in _handlers)
                    ((Action<T>) handler)(args);
        }

        public static void ClearHandlers()
        {
            _handlers = null;
        }
    }
}
