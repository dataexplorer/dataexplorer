using DataExplorer.Application.Web;
using DataExplorer.Application.Web.Commands;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Application.Tests.Web
{
    [TestFixture]
    public class OpenDownloadDataPageCommandHandlerTests
    {
        private OpenDownloadDataPageCommandHandler _handler;
        private Mock<IProcess> _mockProcess;

        [SetUp]
        public void SetUp()
        {
            _mockProcess = new Mock<IProcess>();
            _handler = new OpenDownloadDataPageCommandHandler(_mockProcess.Object);
        }

        [Test]
        public void TestLaunchDownloadDataPageShouldLaunchPage()
        {
            _handler.Execute(new OpenDownloadDataPageCommand());
            _mockProcess.Verify(p => p.Start("http://www.data-explorer.com/data/"));
        }
    }
}
