using DataExplorer.Application.Application;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Tests.Application.Application
{
    [TestFixture]
    public class ApplicationServiceTests
    {
        [Test]
        public void TestExitShouldExitApplication()
        {
            var mockApplication = new Mock<IApplication>();
            var fileMenuService = new ApplicationService(mockApplication.Object);
            fileMenuService.Exit();
            mockApplication.Verify(p => p.ShutDown(), Times.Once());
        }
    }
}
