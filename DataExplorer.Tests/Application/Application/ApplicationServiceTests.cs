using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application;
using DataExplorer.Application.Application;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Tests.Application.FileMenu
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
