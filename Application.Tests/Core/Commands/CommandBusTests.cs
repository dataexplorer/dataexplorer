using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Core.Commands;
using Moq;
using Ninject;
using NUnit.Framework;

namespace DataExplorer.Application.Tests.Core.Commands
{
    [TestFixture]
    public class CommandBusTests
    {
        private CommandBus _bus;
        private IKernel _kernel;
        private FakeCommandHandler _handler;
        private FakeCommand _command;

        [SetUp]
        public void SetUp()
        {
            _command = new FakeCommand();
            _handler = new FakeCommandHandler();
            
            _kernel = new StandardKernel();
            _kernel.Bind<ICommandHandler<FakeCommand>>()
                .ToConstant(_handler);

            _bus = new CommandBus();

            CommandBus.Kernel = _kernel;
        }

        [Test]
        public void TestExecuteShouldExecuteCommand()
        {
            _bus.Execute(_command);
            Assert.That(_handler.WasExecuted, Is.True);
        }
    }
}
