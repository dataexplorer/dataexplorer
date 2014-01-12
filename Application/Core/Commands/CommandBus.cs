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

        public void Execute<T>(T command) where T : ICommand
        {
            var handler = Kernel.Get<ICommandHandler<T>>();

            handler.Execute(command);
        }
    }
}
