using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Core.Commands;
using DataExplorer.Presentation;
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
        private Mock<ICommandLogger> _mockLogger;
        private Mock<IExceptionDialogService> _mockDialogService;
        private FakeCommandHandler _handler;
        private FakeCommand _command;

        [SetUp]
        public void SetUp()
        {
            _command = new FakeCommand();
            _handler = new FakeCommandHandler();
            
            _mockLogger = new Mock<ICommandLogger>();
            _mockDialogService = new Mock<IExceptionDialogService>();

            _kernel = new StandardKernel();
            _kernel.Bind<ICommandHandler<FakeCommand>>()
                .ToConstant(_handler);

            _bus = new CommandBus(
                _mockLogger.Object,
                _mockDialogService.Object);

            CommandBus.Kernel = _kernel;
        }

        [Test]
        public void TestExecuteShouldLogExecutingMessage()
        {
            _bus.Execute(_command);
            _mockLogger.Verify(p => p.LogExecuting(_command), Times.Once());
        }

        [Test]
        public void TestExecuteShouldExecuteCommand()
        {
            _bus.Execute(_command);
            Assert.That(_handler.WasExecuted, Is.True);
        }

        [Test]
        public void TestExecuteShouldLogExecutedMessage()
        {
            _bus.Execute(_command);
            _mockLogger.Verify(p => p.LogExecuting(_command), Times.Once());
        }

        [Test]
        public void TestExecuteShouldLogExceptions()
        {
            _handler.ThrowException = true;
            _bus.Execute(_command);
            _mockLogger.Verify(p => p.LogException(It.IsAny<Exception>()), Times.Once());
        }

        [Test]
        public void TestExecuteShouldShowExceptionDialog()
        {
            _handler.ThrowException = true;
            _bus.Execute(_command);
            _mockDialogService.Verify(p => p.Show(
                It.IsAny<Exception>()), 
                Times.Once());
        }
    }
}
