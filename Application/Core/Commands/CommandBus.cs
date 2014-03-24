﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Core.Logs;
using Ninject;

namespace DataExplorer.Application.Core.Commands
{
    public class CommandBus : ICommandBus
    {
        public static IKernel Kernel;
        private readonly ICommandLogger _logger;

        public CommandBus(ICommandLogger logger)
        {
            _logger = logger;
        }

        public void Execute(ICommand command)
        {
            _logger.LogExecuting(command);

            var handlerType = typeof (ICommandHandler<>)
                .MakeGenericType(command.GetType());

            dynamic handler = Kernel.Get(handlerType);

            handler.Execute((dynamic) command);

            _logger.LogExecuted(command);
        }
    }
}
