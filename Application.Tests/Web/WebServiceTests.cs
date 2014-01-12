using DataExplorer.Application.Web;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Application.Tests.Web
{
    [TestFixture]
    public class WebServiceTests
    {
        private WebService _service;
        private Mock<IProcess> _mockProcess;

        [SetUp]
        public void SetUp()
        {
            _mockProcess = new Mock<IProcess>();
            _service = new WebService(_mockProcess.Object);
        }

        [Test]
        public void TestLaunchDownloadDataPageShouldLaunchPage()
        {
            _service.LaunchDownloadDataPage();
            _mockProcess.Verify(p => p.Start("http://www.data-explorer.com/data/"));
        }
    }
}
