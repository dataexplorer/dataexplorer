using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Project;
using DataExplorer.Application.Serialization;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Events;
using DataExplorer.Domain.Projects;
using DataExplorer.Domain.Rows;
using DataExplorer.Domain.ScatterPlots;
using DataExplorer.Domain.Views;
using DataExplorer.Persistence.Columns;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Tests.Application.Project
{
    [TestFixture]
    public class ProjectServiceTests
    {
        private ProjectService _service;
        private Mock<ISerializationService> _mockSerializationService;
        private Mock<IColumnRepository> _mockColumnRepository;
        private Mock<IRowRepository> _mockRowRepository;
        private Mock<IViewRepository> _mockViewRepository;
        private Column _column;
        private List<Column> _columns;
        private Row _row;
        private List<Row> _rows;
        private IScatterPlot _view;
        private List<IScatterPlot> _views;

        [SetUp]
        public void SetUp()
        {
            _column = new Column(1, 0, "Column 1");
            _columns = new List<Column> { _column };
            _row = new Row();
            _rows = new List<Row> { _row };
            _view = new DataExplorer.Domain.ScatterPlots.ScatterPlot();
            _views = new List<IScatterPlot> { _view };
            _mockColumnRepository = new Mock<IColumnRepository>();
            _mockRowRepository = new Mock<IRowRepository>();
            _mockViewRepository = new Mock<IViewRepository>();
            _mockSerializationService = new Mock<ISerializationService>();
            _mockSerializationService.Setup(p => p.GetColumns()).Returns(_columns);
            _mockSerializationService.Setup(p => p.GetRows()).Returns(_rows);
            _mockSerializationService.Setup(p => p.GetViews()).Returns(_views);
            _service = new ProjectService(
                _mockSerializationService.Object,
                _mockColumnRepository.Object,
                _mockRowRepository.Object,
                _mockViewRepository.Object);
        }

        [Test]
        public void TestOpenProjectShouldAddColumnsToTheRepository()
        {
            _service.OpenProject();
            _mockColumnRepository.Verify(p => p.Add(_column), Times.Once());
        }

        [Test]
        public void TestOpenProjectShouldAddRowsToTheRowRepository()
        {
            _service.OpenProject();
            _mockRowRepository.Verify(p => p.Add(_row), Times.Once());
        }

        [Test]
        public void TestOpenProjectShouldAddViewsToTheViewRepository()
        {
            _service.OpenProject();
            _mockViewRepository.Verify(p => p.Add(_view));
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
