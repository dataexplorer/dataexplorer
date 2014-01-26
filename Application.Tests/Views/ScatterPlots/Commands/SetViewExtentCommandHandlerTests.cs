using System.Windows;
using DataExplorer.Application.Views;
using DataExplorer.Application.Views.ScatterPlots.Commands;
using DataExplorer.Domain.Tests.Views.ScatterPlots;
using DataExplorer.Domain.Views;
using DataExplorer.Domain.Views.ScatterPlots;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Application.Tests.Views.ScatterPlots.Commands
{
    [TestFixture]
    public class SetViewExtentCommandHandlerTests
    {
        private SetViewExtentCommandHandler _handler;
        private Mock<IViewRepository> _mockRepository;
        private ScatterPlot _scatterPlot;
        private Rect _viewExtent;

        [SetUp]
        public void SetUp()
        {
            _viewExtent = new Rect();
            _scatterPlot = new ScatterPlotBuilder().Build();
            _mockRepository = new Mock<IViewRepository>();
            _mockRepository.Setup(p => p.Get<ScatterPlot>()).Returns(_scatterPlot);
            _handler = new SetViewExtentCommandHandler(_mockRepository.Object);
        }

        [Test]
        public void TestSetViewExtentShouldSetViewExtent()
        {
            _handler.Execute(new SetViewExtentCommand(_viewExtent));
            Assert.That(_scatterPlot.GetViewExtent(), Is.EqualTo(_viewExtent));
        }
    }
}
