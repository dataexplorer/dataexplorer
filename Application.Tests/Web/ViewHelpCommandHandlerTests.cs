using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Web.Commands;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Application.Tests.Web
{
    [TestFixture]
    public class ViewHelpCommandHandlerTests
    {
        private ViewHelpCommandHandler _handler;
        private Mock<IProcess> _mockProcess;

        [SetUp]
        public void SetUp()
        {
            _mockProcess = new Mock<IProcess>();
            _handler = new ViewHelpCommandHandler(_mockProcess.Object);
        }

        [Test]
        public void TestLaunchDownloadDataPageShouldLaunchPage()
        {
            _handler.Execute(new ViewHelpCommand());
            _mockProcess.Verify(p => p.Start("http://www.data-explorer.com/support/"));
        }
    }
}
