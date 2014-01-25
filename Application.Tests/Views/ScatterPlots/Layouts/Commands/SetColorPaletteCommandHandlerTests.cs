using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Columns;
using DataExplorer.Application.Core.Events;
using DataExplorer.Application.Views;
using DataExplorer.Application.Views.ScatterPlots.Layouts.Commands;
using DataExplorer.Application.Views.ScatterPlots.Layouts.Events;
using DataExplorer.Domain;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Tests.Colors;
using DataExplorer.Domain.Tests.Columns;
using DataExplorer.Domain.Tests.Views.ScatterPlots;
using DataExplorer.Domain.Views.ScatterPlots;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Application.Tests.Views.ScatterPlots.Layouts.Commands
{
    [TestFixture]
    public class SetColorPaletteCommandHandlerTests
    {
        private SetColorPaletteCommandHandler _handler;
        private Mock<IViewRepository> _mockRepository;
        private Mock<IEventBus> _mockEventBus;
        private ScatterPlot _scatterPlot;
        private ScatterPlotLayout _layout;
        private ColorPalette _colorPalette;

        [SetUp]
        public void SetUp()
        {
            _colorPalette = new ColorPaletteBuilder().Build();
            _layout = new ScatterPlotLayoutBuilder().Build();
            _scatterPlot = new ScatterPlotBuilder()
                .WithLayout(_layout)
                .Build();
            
            _mockRepository = new Mock<IViewRepository>();
            _mockRepository.Setup(p => p.Get<ScatterPlot>())
                .Returns(_scatterPlot);

            _mockEventBus = new Mock<IEventBus>();
            
            _handler = new SetColorPaletteCommandHandler(
                _mockRepository.Object,
                _mockEventBus.Object);
        }

        [Test]
        public void TestExecuteShouldSetColumn()
        {
            _handler.Execute(new SetColorPaletteCommand(_colorPalette));
            Assert.That(_layout.ColorPalette, Is.EqualTo(_colorPalette));
        }

        [Test]
        public void TestExecuteShouldRaiseLayoutChangedEvent()
        {
            _handler.Execute(new SetColorPaletteCommand(_colorPalette));
            _mockEventBus.Verify(p => p.Raise(It.IsAny<LayoutChangedEvent>()));
        }
    }
}
