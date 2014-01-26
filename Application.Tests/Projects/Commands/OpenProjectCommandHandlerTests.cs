using System.Xml.Linq;
using DataExplorer.Application.Application;
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
    public class OpenProjectCommandHandlerTests
    {
        private OpenProjectCommandHandler _handler;
        private Mock<IDialogService> _mockDialogService;
        private Mock<IEventBus> _mockEventBus;
        private Mock<IApplicationStateService> _mockStateService;
        private Mock<IDataContext> _mockDataContext;
        private Mock<IXmlFileService> _mockXmlFileService;
        private Mock<IProjectSerializer> _mockSerializer;
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
            _mockDialogService.Setup(p => p.ShowOpenDialog()).Returns(_filePath);

            _mockEventBus = new Mock<IEventBus>();

            _mockStateService = new Mock<IApplicationStateService>();

            _mockDataContext = new Mock<IDataContext>();

            _mockXmlFileService = new Mock<IXmlFileService>();
            _mockXmlFileService.Setup(p => p.Load(_filePath)).Returns(_xProject);

            _mockSerializer = new Mock<IProjectSerializer>();
            _mockSerializer.Setup(p => p.Deserialize(_xProject)).Returns(_project);
            
            _handler = new OpenProjectCommandHandler(
                _mockDialogService.Object,
                _mockEventBus.Object,
                _mockStateService.Object,
                _mockDataContext.Object,
                _mockXmlFileService.Object,
                _mockSerializer.Object);
        }

        [Test]
        public void TestOpenProjectShouldReturnNoFileIsSelected()
        {
            _mockDialogService.Setup(p => p.ShowOpenDialog()).Returns((string) null);
            _handler.Execute(new OpenProjectCommand());
            _mockDataContext.Verify(p => p.SetProject(_project), Times.Never());
            _mockEventBus.Verify(p => p.Raise(It.IsAny<ProjectOpenedEvent>()), Times.Never());
        }

        [Test]
        public void TestOpenProjectShouldRaiseProjectClosingEvent()
        {
            _handler.Execute(new OpenProjectCommand());
            _mockEventBus.Verify(p => p.Raise(It.IsAny<ProjectClosingEvent>()), Times.Once());
        }

        [Test]
        public void TestExecuteShouldClearSelectedFilter()
        {
            _handler.Execute(new OpenProjectCommand());
            _mockStateService.Verify(p => p.ClearSelectedFilter(), Times.Once());
        }

        [Test]
        public void TestExecuteShouldClearSelectedRows()
        {
            _handler.Execute(new OpenProjectCommand());
            _mockStateService.Verify(p => p.ClearSelectedRows(), Times.Once());
        }

        [Test]
        public void TestOpenProjectShouldClearTheDataContext()
        {
            _handler.Execute(new OpenProjectCommand());
            _mockDataContext.Verify(p => p.Clear(), Times.Once());
        }

        [Test]
        public void TestOpenProjectShouldRaiseProjectClosedEvent()
        {
            _handler.Execute(new OpenProjectCommand());
            _mockEventBus.Verify(p => p.Raise(It.IsAny<ProjectClosedEvent>()), Times.Once());
        }

        [Test]
        public void TestOpenProjectShouldRaiseProjectOpeningEvent()
        {
            _handler.Execute(new OpenProjectCommand());
            _mockEventBus.Verify(p => p.Raise(It.IsAny<ProjectOpeningEvent>()), Times.Once());
        }

        [Test]
        public void TestOpenProjectShouldSetTheProjectOnTheDataContext()
        {
            _handler.Execute(new OpenProjectCommand());
            _mockDataContext.Verify(p => p.SetProject(_project), Times.Once());
        }

        [Test]
        public void TestOpenProjectShouldRaiseProjectOpenedEvent()
        {
            _handler.Execute(new OpenProjectCommand());
            _mockEventBus.Verify(p => p.Raise(It.IsAny<ProjectOpenedEvent>()), Times.Once());
        }
    }
}
