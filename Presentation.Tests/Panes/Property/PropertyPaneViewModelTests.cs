using System;
using System.Collections.Generic;
using System.Linq;
using DataExplorer.Application;
using DataExplorer.Application.Columns;
using DataExplorer.Application.Columns.Queries;
using DataExplorer.Application.Core.Queries;
using DataExplorer.Application.Importers.CsvFiles.Events;
using DataExplorer.Application.Projects.Events;
using DataExplorer.Application.Rows;
using DataExplorer.Application.Rows.Events;
using DataExplorer.Application.Rows.Queries;
using DataExplorer.Domain.Rows;
using DataExplorer.Domain.Tests.Rows;
using DataExplorer.Presentation.Panes.Property;
using DataExplorer.Presentation.Tests.Core;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Presentation.Tests.Panes.Property
{
    [TestFixture]
    public class PropertyPaneViewModelTests : ViewModelTests
    {
        private PropertyPaneViewModel _viewModel;
        private Mock<IQueryBus> _mockQueryBus;
        private Mock<IProcess> _mockProcess;
        private List<ColumnDto> _columns;
        private ColumnDto _column;
        private Row _row;
        
        [SetUp]
        public void SetUp()
        {
            _column = new ColumnDto() { Index = 0, Name = "Column 1" };
            _columns = new List<ColumnDto> { _column };
            _row = new RowBuilder().WithField("Field 1").Build();

            _mockQueryBus = new Mock<IQueryBus>();
            _mockQueryBus.Setup(p => p.Execute(It.IsAny<GetAllColumnsQuery>()))
                .Returns(_columns);
            _mockQueryBus.Setup(p => p.Execute(It.IsAny<GetLastSelectedRowQuery>()))
                .Returns(_row);

            _mockProcess = new Mock<IProcess>();

            _viewModel = new PropertyPaneViewModel(
                _mockQueryBus.Object,
                _mockProcess.Object);
        }

        [Test]
        public void TestPropertiesShouldReturnEmptyIfNoSelectedRow()
        {
            _mockQueryBus.Setup(p => p.Execute(It.IsAny<GetLastSelectedRowQuery>()))
                .Returns((Row) null);
            var results = _viewModel.Properties;
            Assert.That(results, Is.Empty);
        }

        [Test]
        public void TestPropertiesShouldReturnPropertyViewModels()
        {
            var results = _viewModel.Properties;
            Assert.That(results.Single(), Is.TypeOf<PropertyViewModel>());
        }

        [Test]
        public void TestHandleSelectedRowsChangedShouldFirePropertiesChangedEvent()
        {
            AssertPropertyChanged(_viewModel, () => _viewModel.Properties, 
                () => _viewModel.Handle(new SelectedRowsChangedEvent()));
        }

        [Test]
        public void TestHandleProjectOpenedShouldFirePropertiesChangedEvent()
        {
            AssertPropertyChanged(_viewModel, () => _viewModel.Properties,
                () => _viewModel.Handle(new ProjectOpenedEvent()));
        }

        [Test]
        public void TestHandleProjectClosedShouldFirePropertiesChangedEvent()
        {
            AssertPropertyChanged(_viewModel, () => _viewModel.Properties,
                () => _viewModel.Handle(new ProjectClosedEvent()));
        }

        [Test]
        public void TestHandleSourceImportedShouldFirePropertiesChangedEvent()
        {
            AssertPropertyChanged(_viewModel, () => _viewModel.Properties,
                () => _viewModel.Handle(new SourceImportedEvent()));
        }
    }
}
