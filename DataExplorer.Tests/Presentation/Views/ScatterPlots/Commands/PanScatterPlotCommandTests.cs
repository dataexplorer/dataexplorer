using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DataExplorer.Application.Views.ScatterPlots;
using DataExplorer.Presentation.Views.ScatterPlots.Commands;
using DataExplorer.Presentation.Views.ScatterPlots.Scalers;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Tests.Presentation.Views.ScatterPlots.Commands
{
    [TestFixture]
    public class PanScatterPlotCommandTests
    {
        private PanScatterPlotCommand _command;
        private Mock<IScatterPlotService> _mockService;
        private Mock<IVectorScaler> _mockScaler;
        private Rect _viewExtent;
        private Size _controlSize;
        private Vector _sourceVector;
        private Vector _targetVector;

        [SetUp]
        public void SetUp()
        {
            _viewExtent = new Rect();
            _controlSize = new Size();
            _sourceVector = new Vector();
            _targetVector = new Vector();

            _mockService = new Mock<IScatterPlotService>();
            _mockService.Setup(p => p.GetViewExtent()).Returns(_viewExtent);

            _mockScaler = new Mock<IVectorScaler>();
            _mockScaler.Setup(p => p.ScaleVector(_sourceVector, _controlSize, _viewExtent)).Returns(_targetVector);
            
            _command = new PanScatterPlotCommand(
                _mockService.Object,
                _mockScaler.Object);
        }

        [Test]
        public void TestExecuteShouldPan()
        {
            _command.Execute(_sourceVector, _controlSize);
            _mockService.Verify(p => p.Pan(_targetVector), Times.Once());
            
        }
    }
}
