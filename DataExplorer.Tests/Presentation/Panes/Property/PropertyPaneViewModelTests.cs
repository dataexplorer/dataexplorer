using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Columns;
using DataExplorer.Application.Core.Events;
using DataExplorer.Application.Importers.CsvFiles.Events;
using DataExplorer.Application.Rows;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Rows;
using DataExplorer.Infrastructure.Process;
using DataExplorer.Presentation.Panes.Property;
using DataExplorer.Tests.Domain.Columns;
using DataExplorer.Tests.Domain.Rows;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Tests.Presentation.Panes.Property
{
    [TestFixture]
    public class PropertyPaneViewModelTests
    {
        private PropertyPaneViewModel _viewModel;
        private Mock<IColumnService> _mockColumnService;
        private Mock<IRowService> _mockRowService;
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

            _mockColumnService = new Mock<IColumnService>();
            _mockColumnService.Setup(p => p.GetAllColumns()).Returns(_columns);

            _mockRowService = new Mock<IRowService>();
            _mockRowService.Setup(p => p.GetSelectedRow()).Returns(_row);

            _mockProcess = new Mock<IProcess>();

            _viewModel = new PropertyPaneViewModel(
                _mockColumnService.Object,
                _mockRowService.Object,
                _mockProcess.Object);
        }

        [Test]
        public void TestPropertiesShouldReturnEmptyIfNoSelectedRow()
        {
            _mockRowService.Setup(p => p.GetSelectedRow()).Returns((Row) null);
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
            AssertPropertiesChangedEventWasRaised(() => _viewModel.Handle(new SelectedRowsChangedEvent()));
        }

        [Test]
        public void TestHandleCsvFileImportingShouldFirePropertiesChangedEvent()
        {
            AssertPropertiesChangedEventWasRaised(() => _viewModel.Handle(new CsvFileImportingEvent()));
        }

        [Test]
        public void TestHandleProjectOpeningShouldFirePropertiesChangedEvent()
        {
            AssertPropertiesChangedEventWasRaised(() => _viewModel.Handle(new SelectedRowsChangedEvent()));
        }

        private void AssertPropertiesChangedEventWasRaised(Action action)
        {
            var wasRaised = false;
            _viewModel.PropertyChanged += (s, e) => { wasRaised = e.PropertyName == "Properties"; };
            action.Invoke();
            Assert.That(wasRaised, Is.True);
        }
    }
}
