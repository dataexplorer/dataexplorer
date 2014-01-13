using System.Windows;
using DataExplorer.Application.Views.ScatterPlots.Layouts.Commands;
using DataExplorer.Domain.Events;
using DataExplorer.Domain.Tests.Columns;
using DataExplorer.Domain.Views;
using DataExplorer.Domain.Views.ScatterPlots;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Application.Tests.Views.ScatterPlots.Layouts.Commands
{
    [TestFixture]
    public class ClearLayoutCommandHandlerTests
    {
        private ClearLayoutCommandHandler _handler;
        private Mock<IViewRepository> _mockRepository;
        private ScatterPlot _scatterPlot;
        private ScatterPlotLayout _layout;

        [SetUp]
        public void SetUp()
        {
            var column = new ColumnBuilder().Build();
            _layout = new ScatterPlotLayout()
            {
                XAxisColumn = column,
                YAxisColumn = column
            };
            _scatterPlot = new ScatterPlot(_layout, new Rect(), null);
            
            _mockRepository = new Mock<IViewRepository>();
            _mockRepository.Setup(p => p.Get<ScatterPlot>()).Returns(_scatterPlot);

            _handler = new ClearLayoutCommandHandler(_mockRepository.Object);
        }

        [Test]
        public void TestExecuteShouldClearXAxis()
        {
            _handler.Execute(new ClearLayoutCommand());
            Assert.That(_layout.XAxisColumn, Is.Null);
        }

        [Test]
        public void TestExecuteShouldClearYAxis()
        {
            _handler.Execute(new ClearLayoutCommand());
            Assert.That(_layout.YAxisColumn, Is.Null);
        }

        [Test]
        public void TestExecuteShouldRaiseLayoutChangedEvent()
        {
            var wasRaised = false;
            DomainEvents.Register<ScatterPlotLayoutColumnChangedEvent>(p => { wasRaised = true; });
            _handler.Execute(new ClearLayoutCommand());
            Assert.That(wasRaised, Is.True);
            DomainEvents.ClearHandlers();
        }
    }
}
