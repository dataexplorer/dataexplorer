using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DataExplorer.Application.Columns;
using DataExplorer.Application.Importers;
using DataExplorer.Application.ScatterPlots;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Projects;
using DataExplorer.Domain.ScatterPlots;
using DataExplorer.Domain.Views;
using DataExplorer.Persistence.Columns;
using DataExplorer.Tests.Domain.Columns;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Tests.Application.ScatterPlots
{
    [TestFixture]
    public class ScatterPlotLayoutServiceTests
    {
        private ScatterPlotLayoutService _service;
        private Mock<IViewRepository> _mockViewRepository;
        private Mock<IColumnRepository> _mockColumnRepository;
        private Mock<IColumnAdapter> _mockColumnAdapter;

        [SetUp]
        public void SetUp()
        {
            _mockViewRepository = new Mock<IViewRepository>();
            _mockColumnRepository = new Mock<IColumnRepository>();
            _mockColumnAdapter = new Mock<IColumnAdapter>();
            _service = new ScatterPlotLayoutService(
                _mockViewRepository.Object,
                _mockColumnRepository.Object,
                _mockColumnAdapter.Object);
        }

        [Test]
        public void TestGetColumnsShouldReturnColumns()
        {
            var column = new ColumnBuilder().Build();
            var columns = new List<Column> { column };
            var columnDto = new ColumnDto { Index = column.Index };
            _mockColumnRepository.Setup(p => p.GetAll()).Returns(columns);
            _mockColumnAdapter.Setup(p => p.Adapt(column)).Returns(columnDto);
            var result = _service.GetColumns();
            Assert.That(result.Single().Index, Is.EqualTo(column.Index));
        }

        [Test]
        public void TestGetXColumnShouldReturnXColumn()
        {
            var column = new ColumnBuilder().Build();
            var columnDto = new ColumnDto() { Index = column.Index };
            var layout = new ScatterPlotLayout() { XAxisColumn = column };
            var scatterPlot = new ScatterPlot(new Rect(), null, layout);
            _mockViewRepository.Setup(p => p.Get<ScatterPlot>()).Returns(scatterPlot);
            _mockColumnAdapter.Setup(p => p.Adapt(column)).Returns(columnDto);
            var result = _service.GetXColumn();
            Assert.That(result.Index, Is.EqualTo(column.Index));
        }

        [Test]
        public void TestSetXColumnShouldSetXColumn()
        {
            var column = new ColumnBuilder().Build();
            var columnDto = new ColumnDto() { Id = 1 };
            var layout = new ScatterPlotLayout();
            var scatterPlot = new ScatterPlot(new Rect(), null, layout);
            _mockColumnRepository.Setup(p => p.Get(1)).Returns(column);
            _mockViewRepository.Setup(p => p.Get<ScatterPlot>()).Returns(scatterPlot);
            _service.SetXColumn(columnDto);
            Assert.That(layout.XAxisColumn, Is.EqualTo(column));
        }

        [Test]
        public void TestGetYColumnShouldReturnYColumn()
        {
            var column = new ColumnBuilder().Build();
            var columnDto = new ColumnDto() { Index = column.Index };
            var layout = new ScatterPlotLayout() { YAxisColumn = column };
            var scatterPlot = new ScatterPlot(new Rect(), null, layout);
            _mockViewRepository.Setup(p => p.Get<ScatterPlot>()).Returns(scatterPlot);
            _mockColumnAdapter.Setup(p => p.Adapt(column)).Returns(columnDto);
            var result = _service.GetYColumn();
            Assert.That(result.Index, Is.EqualTo(column.Index));
        }

        [Test]
        public void TestSetYColumnShouldSetYColumn()
        {
            var column = new ColumnBuilder().Build();
            var columnDto = new ColumnDto() { Id = 1 };
            var layout = new ScatterPlotLayout();
            var scatterPlot = new ScatterPlot(new Rect(), null, layout);
            _mockColumnRepository.Setup(p => p.Get(1)).Returns(column);
            _mockViewRepository.Setup(p => p.Get<ScatterPlot>()).Returns(scatterPlot);
            _service.SetYColumn(columnDto);
            Assert.That(layout.YAxisColumn, Is.EqualTo(column));
        }

        [Test]
        public void TestHandleProjectOpenedShouldRaiseLayoutColumnsChangedEvent()
        {
            var args = new ProjectOpenedEvent();
            var wasHandled = false;
            _service.LayoutColumnsChangedEvent += (s, e) => { wasHandled = true; };
            _service.Handle(args);
            Assert.That(wasHandled, Is.True);
        }

        [Test]
        public void TestHandleProjectClosedShouldRaiseLayoutColumnsChangedEvent()
        {
            var args = new ProjectClosedEvent();
            var wasHandled = false;
            _service.LayoutColumnsChangedEvent += (s, e) => { wasHandled = true; };
            _service.Handle(args);
            Assert.That(wasHandled, Is.True);
        }

        [Test]
        public void TestHandleDataImportedEventShouldRaiseLayoutColumnsChangedEvent()
        {
            var args = new DataImportedEvent();
            var wasHandled = false;
            _service.LayoutColumnsChangedEvent += (s, e) => { wasHandled = true; };
            _service.Handle(args);
            Assert.That(wasHandled, Is.True);
        }
    }
}
