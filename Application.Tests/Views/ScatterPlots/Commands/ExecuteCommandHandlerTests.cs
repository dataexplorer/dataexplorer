using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Rows;
using DataExplorer.Application.Views;
using DataExplorer.Application.Views.ScatterPlots.Commands;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Rows;
using DataExplorer.Domain.Tests.Columns;
using DataExplorer.Domain.Tests.Rows;
using DataExplorer.Domain.Tests.Views.ScatterPlots;
using DataExplorer.Domain.Views.ScatterPlots;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Application.Tests.Views.ScatterPlots.Commands
{
    [TestFixture]
    public class ExecuteCommandHandlerTests
    {
        private ExecuteCommandHandler _handler;
        private Mock<IViewRepository> _mockViewRepository;
        private Mock<IRowRepository> _mockRowRepository;
        private Mock<IProcess> _mockProcess;
        private ScatterPlot _view;
        private ScatterPlotLayout _layout;
        private Column _column;
        private Row _row;
        

        [SetUp]
        public void SetUp()
        {
            _row = new RowBuilder()
                .WithId(1)
                .WithField("http://www.test.com")
                .Build();
            _column = new ColumnBuilder()
                .WithIndex(0)
                .Build();
            _layout = new ScatterPlotLayoutBuilder()
                .WithLinkColumn(_column)
                .Build();
            _view = new ScatterPlotBuilder()
                .WithLayout(_layout)
                .Build();

            _mockViewRepository = new Mock<IViewRepository>();
            _mockViewRepository.Setup(p => p.Get<ScatterPlot>())
                .Returns(_view);

            _mockRowRepository = new Mock<IRowRepository>();
            _mockRowRepository.Setup(p => p.Get(_row.Id))
                .Returns(_row);

            _mockProcess = new Mock<IProcess>();

            _handler = new ExecuteCommandHandler(
                _mockViewRepository.Object,
                _mockRowRepository.Object,
                _mockProcess.Object);
        }

        [Test]
        public void TestExecuteShouldReturnIfLinkColumnIsNull()
        {
            _layout.LinkColumn = null;
            _handler.Execute(new ExecuteCommand(_row.Id));
            _mockProcess.Verify(p => p.Start(It.IsAny<string>()), Times.Never());
        }

        [Test]
        public void TestExecuteShouldStartLink()
        {
            _handler.Execute(new ExecuteCommand(_row.Id));
            _mockProcess.Verify(p => p.Start((string) _row[0]), Times.Once());
        }
    }
}
