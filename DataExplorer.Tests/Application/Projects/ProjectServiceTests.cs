using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Projects;
using DataExplorer.Application.Serialization;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Events;
using DataExplorer.Domain.Projects;
using DataExplorer.Domain.Rows;
using DataExplorer.Domain.ScatterPlots;
using DataExplorer.Domain.Views;
using DataExplorer.Persistence;
using DataExplorer.Persistence.Columns;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Tests.Application.Projects
{
    [TestFixture]
    public class ProjectServiceTests
    {
        private ProjectService _service;
        private Mock<ISerializationService> _mockSerializationService;
        private Mock<IDataContext> _mockDataContext;
        private Project _project;
        
        [SetUp]
        public void SetUp()
        {
            _project = new Project();
            _mockSerializationService = new Mock<ISerializationService>();
            _mockDataContext = new Mock<IDataContext>();
            _mockSerializationService.Setup(p => p.GetProject()).Returns(_project);
            _service = new ProjectService(
                _mockSerializationService.Object,
                _mockDataContext.Object);
        }

        [Test]
        public void TestOpenProjectShouldSetTheProjectOnTheDataContext()
        {
            _service.OpenProject();
            _mockDataContext.Verify(p => p.SetProject(_project), Times.Once());
        }
        
        [Test]
        public void TestOpenProjectShouldRaiseProjectOpenedEvent()
        {
            var wasProjectOpened = false;
            DomainEvents.Register<ProjectOpenedEvent>(p => wasProjectOpened = true);
            _service.OpenProject();
            Assert.That(wasProjectOpened, Is.True);
            DomainEvents.ClearHandlers();
        }

        [Test]
        public void TestCloseProjectShouldClearTheDataContext()
        {
            _service.CloseProject();
            _mockDataContext.Verify(p => p.Clear(), Times.Once());
        }

        [Test]
        public void TestCloseProjectShouldRaiseProjectClosedEvent()
        {
            var wasProjectClosed = false;
            DomainEvents.Register<ProjectClosedEvent>(p => wasProjectClosed = true);
            _service.CloseProject();
            Assert.That(wasProjectClosed, Is.True);
            DomainEvents.ClearHandlers();
        }
    }
}
