using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DataExplorer.Application.Columns;
using DataExplorer.Application.ScatterPlots.Layouts.Commands;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.ScatterPlots;
using DataExplorer.Domain.Views;
using DataExplorer.Tests.Domain.Columns;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Tests.Application.ScatterPlots.Layouts.Commands
{
    [TestFixture]
    public class SetXColumnCommandTests
    {
        private SetXColumnCommand _command;
        private Mock<IColumnRepository> _mockColumnRepository;
        private Mock<IViewRepository> _mockRepository;
        private ScatterPlot _scatterPlot;
        private ScatterPlotLayout _layout;
        private Column _column;
        private ColumnDto _columnDto;

        [SetUp]
        public void SetUp()
        {
            _columnDto = new ColumnDto() { Id = 1 };
            _column = new ColumnBuilder().Build();
            _layout = new ScatterPlotLayout();
            _scatterPlot = new ScatterPlot(new Rect(), null, _layout);

            _mockColumnRepository = new Mock<IColumnRepository>();
            _mockColumnRepository.Setup(p => p.Get(_columnDto.Id)).Returns(_column);

            _mockRepository = new Mock<IViewRepository>();
            _mockRepository.Setup(p => p.Get<ScatterPlot>()).Returns(_scatterPlot);

            _command = new SetXColumnCommand(
                _mockColumnRepository.Object,
                _mockRepository.Object);
        }

        [Test]
        public void TestSetXColumnShouldSetXColumn()
        {
            _command.Execute(_columnDto);
            Assert.That(_layout.XAxisColumn, Is.EqualTo(_column));
        }
    }
}
