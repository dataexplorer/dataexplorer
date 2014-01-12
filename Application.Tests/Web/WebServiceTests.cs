using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Web;
using DataExplorer.Infrastructure.Process;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Tests.Application.Web
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
