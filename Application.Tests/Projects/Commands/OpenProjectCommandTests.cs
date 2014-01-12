using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DataExplorer.Application.Core.Events;
using DataExplorer.Application.Projects.Commands;
using DataExplorer.Application.Projects.Events;
using DataExplorer.Domain.Projects;
using DataExplorer.Infrastructure.Serializers;
using DataExplorer.Infrastructure.XmlFiles;
using DataExplorer.Persistence;
using DataExplorer.Presentation.Dialogs;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Tests.Application.Projects.Commands
{
    [TestFixture]
    public class OpenProjectCommandTests
    {
        private OpenProjectCommand _command;
        private Mock<IDialogService> _mockDialogService;
        private Mock<IXmlFileService> _mockXmlFileService;
        private Mock<IProjectSerializer> _mockSerializer;
        private Mock<IDataContext> _mockDataContext;
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
            _mockDialogService.Setup(p => p.ShowOpenDialog()).Returns(_filePath);

            _mockXmlFileService = new Mock<IXmlFileService>();
            _mockXmlFileService.Setup(p => p.Load(_filePath)).Returns(_xProject);

            _mockSerializer = new Mock<IProjectSerializer>();
            _mockSerializer.Setup(p => p.Deserialize(_xProject)).Returns(_project);

            _mockDataContext = new Mock<IDataContext>();
            
            _mockEventBus = new Mock<IEventBus>();

            _command = new OpenProjectCommand(
                _mockDialogService.Object,
                _mockXmlFileService.Object,
                _mockSerializer.Object,
                _mockDataContext.Object,
                _mockEventBus.Object);
        }

        [Test]
        public void TestOpenProjectShouldReturnNoFileIsSelected()
        {
            _mockDialogService.Setup(p => p.ShowOpenDialog()).Returns((string) null);
            _command.Execute();
            _mockDataContext.Verify(p => p.SetProject(_project), Times.Never());
            _mockEventBus.Verify(p => p.Raise(It.IsAny<ProjectOpenedEvent>()), Times.Never());
        }

        [Test]
        public void TestOpenProjectShouldSetTheProjectOnTheDataContext()
        {
            _command.Execute();
            _mockDataContext.Verify(p => p.SetProject(_project), Times.Once());
        }

        [Test]
        public void TestOpenProjectShouldRaiseProjectOpenedEvent()
        {
            _command.Execute();
            _mockEventBus.Verify(p => p.Raise(It.IsAny<ProjectOpenedEvent>()), Times.Once());
        }
    }
}
