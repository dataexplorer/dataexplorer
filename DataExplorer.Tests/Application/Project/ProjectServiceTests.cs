using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Project;
using DataExplorer.Application.Serialization;
using DataExplorer.Domain.Events;
using DataExplorer.Domain.Projects;
using DataExplorer.Domain.Rows;
using DataExplorer.Domain.ScatterPlots;
using DataExplorer.Domain.Views;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Tests.Application.Project
{
    [TestFixture]
    public class ProjectServiceTests
    {
        private ProjectService _service;
        private Mock<ISerializationService> _mockSerializationService;
        private Mock<IViewRepository> _mockViewRepository;
        private Mock<IRowRepository> _mockRowRepository;
        private List<IScatterPlot> _views;
        private IScatterPlot _view;
        private List<Row> _rows;
        private Row _row;

        [SetUp]
        public void SetUp()
        {
            _view = new DataExplorer.Domain.ScatterPlots.ScatterPlot();
            _views = new List<IScatterPlot> { _view };
            _row = new Row();
            _rows = new List<Row> { _row };
            _mockViewRepository = new Mock<IViewRepository>();
            _mockRowRepository = new Mock<IRowRepository>();
            _mockSerializationService = new Mock<ISerializationService>();
            _mockSerializationService.Setup(p => p.GetViews()).Returns(_views);
            _mockSerializationService.Setup(p => p.GetRows()).Returns(_rows);
            _service = new ProjectService(
                _mockSerializationService.Object,
                _mockViewRepository.Object,
                _mockRowRepository.Object);
        }

        [Test]
        public void TestOpenProjectShouldAddViewsToTheViewRepository()
        {
            _service.OpenProject();
            _mockViewRepository.Verify(p => p.Add(_view));
        }

        [Test]
        public void TestOpenProjectShouldAddRowsToTheRowRepository()
        {
            _service.OpenProject();
            _mockRowRepository.Verify(p => p.Add(_row), Times.Once());
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
    }
}
