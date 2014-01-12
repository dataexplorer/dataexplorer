using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;

namespace DataExplorer.Application.Core.Commands
{
    public class CommandBus : ICommandBus
    {
        public static IKernel Kernel;

        public void Execute(ICommand command)
        {
            var handlerType = typeof (ICommandHandler<>)
                .MakeGenericType(command.GetType());

            dynamic handler = Kernel.Get(handlerType);

            handler.Execute((dynamic) command);
        }
    }
}
