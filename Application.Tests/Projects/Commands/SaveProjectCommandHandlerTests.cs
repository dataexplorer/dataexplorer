using System.Xml.Linq;
using DataExplorer.Application.Core.Events;
using DataExplorer.Application.Projects;
using DataExplorer.Application.Projects.Commands;
using DataExplorer.Application.Projects.Events;
using DataExplorer.Domain.Projects;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Application.Tests.Projects.Commands
{
    [TestFixture]
    public class SaveProjectCommandHandlerTests
    {
        private SaveProjectCommandHandler _handler;
        private Mock<IDialogService> _mockDialogService;
        private Mock<IDataContext> _mockDataContext;
        private Mock<IProjectSerializer> _mockSerializer;
        private Mock<IXmlFileService> _mockFileService;
        private Mock<IEventBus> _mockEventBus;
        private Project _project;
        private XElement _xProject;
        private string _filePath;

        [SetUp]
        public void SetUp()
        {
            _project = new Project();
            _xProject = new XElement("project");
            _filePath = @"C:\Project.xml";

            _mockDialogService = new Mock<IDialogService>();
            _mockDialogService.Setup(p => p.ShowSaveDialog()).Returns(_filePath);

            _mockDataContext = new Mock<IDataContext>();
            _mockDataContext.Setup(p => p.GetProject()).Returns(_project);

            _mockSerializer = new Mock<IProjectSerializer>();
            _mockSerializer.Setup(p => p.Serialize(_project)).Returns(_xProject);
            
            _mockFileService = new Mock<IXmlFileService>();

            _mockEventBus = new Mock<IEventBus>();

            _handler = new SaveProjectCommandHandler(
                _mockDialogService.Object,
                _mockDataContext.Object,
                _mockSerializer.Object,
                _mockFileService.Object,
                _mockEventBus.Object);
        }

        [Test]
        public void TestExecuteShouldReturnIfNoFileIsSelected()
        {
            _mockDialogService.Setup(p => p.ShowSaveDialog()).Returns((string) null);
            _handler.Execute(new SaveProjectCommand());
            _mockFileService.Verify(p => p.Save(_xProject, _filePath), Times.Never());
            _mockEventBus.Verify(p => p.Raise(It.IsAny<ProjectSavedEvent>()), Times.Never());
        }

        [Test]
        public void TestExecuteShouldSaveSerializedProject()
        {
            _handler.Execute(new SaveProjectCommand());
            _mockFileService.Verify(p => p.Save(_xProject, _filePath), Times.Once());
        }

        [Test]
        public void TestExecuteShouldRaiseProjectSavedEvent()
        {
            _handler.Execute(new SaveProjectCommand());
            _mockEventBus.Verify(p => p.Raise(It.IsAny<ProjectSavedEvent>()), Times.Once());
        }
    }
}
