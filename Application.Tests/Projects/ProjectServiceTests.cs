using DataExplorer.Application.Projects;
using DataExplorer.Application.Projects.Commands;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Application.Tests.Projects
{
    [TestFixture]
    public class ProjectServiceTests
    {
        private ProjectService _service;
        private Mock<IOpenProjectCommand> _mockOpenCommand;
        private Mock<ISaveProjectCommand> _mockSaveCommand;
        private Mock<ICloseProjectCommand> _mockCloseCommand;
        
        [SetUp]
        public void SetUp()
        {
            _mockOpenCommand = new Mock<IOpenProjectCommand>();
            _mockSaveCommand = new Mock<ISaveProjectCommand>();
            _mockCloseCommand = new Mock<ICloseProjectCommand>();

            _service = new ProjectService(
                _mockOpenCommand.Object,
                _mockSaveCommand.Object,
                _mockCloseCommand.Object);
        }

        [Test]
        public void TestOpenShouldExecuteOpenCommand()
        {
            _service.OpenProject();
            _mockOpenCommand.Verify(p => p.Execute(), Times.Once());
        }

        [Test]
        public void TestSaveShouldExecuteSaveCommand()
        {
            _service.SaveProject();
            _mockSaveCommand.Verify(p => p.Execute(), Times.Once());
        }

        [Test]
        public void TestCloseShouldExecuteCloseCommand()
        {
            _service.CloseProject();
            _mockCloseCommand.Verify(p => p.Execute(), Times.Once());
        }
    }
}
