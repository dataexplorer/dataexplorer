using System.Windows;
using DataExplorer.Application.Views.ScatterPlots.Layouts.Commands;
using DataExplorer.Domain.Events;
using DataExplorer.Domain.Views;
using DataExplorer.Domain.Views.ScatterPlots;
using DataExplorer.Tests.Domain.Columns;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Tests.Application.Views.ScatterPlots.Layouts.Commands
{
    [TestFixture]
    public class ClearLayoutCommandTests
    {
        private ClearLayoutCommand _command;
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

            _command = new ClearLayoutCommand(_mockRepository.Object);
        }

        [Test]
        public void TestExecuteShouldClearXAxis()
        {
            _command.Execute();
            Assert.That(_layout.XAxisColumn, Is.Null);
        }

        [Test]
        public void TestExecuteShouldClearYAxis()
        {
            _command.Execute();
            Assert.That(_layout.YAxisColumn, Is.Null);
        }

        [Test]
        public void TestExecuteShouldRaiseLayoutChangedEvent()
        {
            var wasRaised = false;
            DomainEvents.Register<ScatterPlotLayoutColumnChangedEvent>(p => { wasRaised = true; });
            _command.Execute();
            Assert.That(wasRaised, Is.True);
            DomainEvents.ClearHandlers();
        }
    }
}
