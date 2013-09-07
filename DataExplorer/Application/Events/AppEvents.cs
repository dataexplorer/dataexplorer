using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Events;
using Ninject;

namespace DataExplorer.Application.Events
{
    public class AppEvents
    {
        public static IKernel Kernel;

        //[ThreadStatic]
        private static List<Delegate> _handlers;

        public static void Register<T>(Action<T> handler) where T : IAppEvent
        {
            if (_handlers == null)
                _handlers = new List<Delegate>();

            _handlers.Add(handler);
        }

        public static void Raise<T>(T args) where T : IAppEvent
        {
            if (Kernel != null)
                foreach (var handler in Kernel.GetAll<IAppHandler<T>>())
                    handler.Handle(args);

            if (_handlers != null)
                foreach (var handler in _handlers.OfType<Action<T>>())
                    handler(args);
        }

        public static void ClearHandlers()
        {
            _handlers = null;
        }
    }
}
