using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Application;
using DataExplorer.Application.Application.Commands;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Application.Tests.Application.Commands
{
    [TestFixture]
    public class ExitCommandHandlerTests
    {
        private ExitCommandHandler _handler;
        private Mock<IApplication> _mockAppication;

        [SetUp]
        public void SetUp()
        {
            _mockAppication = new Mock<IApplication>();

            _handler = new ExitCommandHandler(_mockAppication.Object);
        }

        [Test]
        public void TestExecuteShouldExitApplication()
        {
            _handler.Execute(new ExitCommand());
            _mockAppication.Verify(p => p.ShutDown(), Times.Once());
        }
    }
}
