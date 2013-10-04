using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DataExplorer.Application.Columns;
using DataExplorer.Application.Importers.CsvFiles.Events;
using DataExplorer.Application.ScatterPlots;
using DataExplorer.Application.ScatterPlots.Layouts.Commands;
using DataExplorer.Application.ScatterPlots.Layouts.Queries;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Projects;
using DataExplorer.Domain.ScatterPlots;
using DataExplorer.Domain.Views;
using DataExplorer.Tests.Domain.Columns;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Tests.Application.ScatterPlots
{
    [TestFixture]
    public class ScatterPlotLayoutServiceTests
    {
        private ScatterPlotLayoutService _service;
        private Mock<IGetXColumnQuery> _mockGetXColumnQuery;
        private Mock<ISetXColumnCommand> _mockSetXColumnCommand;
        private Mock<IGetYColumnQuery> _mockGetYColumnQuery;
        private Mock<ISetYColumnCommand> _mockSetYColumnCommand;
        private Mock<IClearLayoutCommand> _mockClearLayoutCommand;
        private ColumnDto _columnDto;

        [SetUp]
        public void SetUp()
        {
            _columnDto = new ColumnDto();
            _mockGetXColumnQuery = new Mock<IGetXColumnQuery>();
            _mockSetXColumnCommand = new Mock<ISetXColumnCommand>();
            _mockGetYColumnQuery = new Mock<IGetYColumnQuery>();
            _mockSetYColumnCommand = new Mock<ISetYColumnCommand>();
            _mockClearLayoutCommand = new Mock<IClearLayoutCommand>();
            _service = new ScatterPlotLayoutService(
                _mockGetXColumnQuery.Object,
                _mockSetXColumnCommand.Object,
                _mockGetYColumnQuery.Object,
                _mockSetYColumnCommand.Object,
                _mockClearLayoutCommand.Object);
        }

        [Test]
        public void TestGetXColumnShouldReturnXColumn()
        {
            _mockGetXColumnQuery.Setup(p => p.Query()).Returns(_columnDto);
            var result = _service.GetXColumn();
            Assert.That(result, Is.EqualTo(_columnDto));
        }

        [Test]
        public void TestSetXColumnShouldSetXColumn()
        {
            _service.SetXColumn(_columnDto);
            _mockSetXColumnCommand.Verify(p => p.Execute(_columnDto), Times.Once());
        }

        [Test]
        public void TestGetYColumnShouldReturnYColumn()
        {
            var columnDto = new ColumnDto();
            _mockGetYColumnQuery.Setup(p => p.Query()).Returns(columnDto);
            var result = _service.GetYColumn();
            Assert.That(result, Is.EqualTo(columnDto));
        }

        [Test]
        public void TestSetYColumnShouldSetYColumn()
        {
            _service.SetYColumn(_columnDto);
            _mockSetYColumnCommand.Verify(p => p.Execute(_columnDto), Times.Once());

        }

        [Test]
        public void TestClearLayoutShouldClearLayout()
        {
            _service.ClearLayout();
            _mockClearLayoutCommand.Verify(p => p.Execute(), Times.Once());
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
            var args = new CsvFileImportedEvent();
            var wasHandled = false;
            _service.LayoutColumnsChangedEvent += (s, e) => { wasHandled = true; };
            _service.Handle(args);
            Assert.That(wasHandled, Is.True);
        }
    }
}
