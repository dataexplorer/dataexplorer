using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using DataExplorer.Application.Columns;
using DataExplorer.Application.Core.Events;
using DataExplorer.Application.Layouts.General.Commands;
using DataExplorer.Application.Views;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Semantics;
using DataExplorer.Domain.Tests.Columns;
using DataExplorer.Domain.Tests.Views.ScatterPlots;
using DataExplorer.Domain.Views.ScatterPlots;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Application.Tests.Layouts.General.Commands
{
    [TestFixture]
    public class AutoLayoutColumnCommandHandlerTests
    {
        private AutoLayoutColumnCommandHandler _handler;
        private Mock<IColumnRepository> _mockColumnRepository;
        private Mock<IViewRepository> _mockViewRepository;
        private Mock<IEventBus> _mockEventBus;
        private ScatterPlot _view;
        private ScatterPlotLayout _layout;
        private Column _column;


        [SetUp]
        public void SetUp()
        {
            _column = new ColumnBuilder()
                .WithId(1)
                .Build();
            _layout = new ScatterPlotLayout();
            _view = new ScatterPlotBuilder()
                .WithLayout(_layout)
                .Build();

            var blankColumn = new ColumnBuilder().Build();
            _layout.XAxisColumn = blankColumn;
            _layout.YAxisColumn = blankColumn;
            _layout.SizeColumn = blankColumn;
            _layout.ColorColumn = blankColumn;
            _layout.ShapeColumn = blankColumn;
            _layout.LabelColumn = blankColumn;
            _layout.LinkColumn = blankColumn;

            _mockColumnRepository = new Mock<IColumnRepository>();
            _mockColumnRepository.Setup(p => p.Get(_column.Id))
                .Returns(_column);

            _mockViewRepository = new Mock<IViewRepository>();
            _mockViewRepository.Setup(p => p.Get<ScatterPlot>())
                .Returns(_view);

            _mockEventBus = new Mock<IEventBus>();

            _handler = new AutoLayoutColumnCommandHandler(
                _mockColumnRepository.Object,
                _mockViewRepository.Object,
                _mockEventBus.Object);
        }

        public void SetUpColumn(Type dataType, SemanticType semanticType)
        {
            _column = new ColumnBuilder()
                .WithId(1)
                .WithDataType(dataType)
                .WithSemanticType(semanticType)
                .Build();
            _mockColumnRepository.Setup(p => p.Get(_column.Id))
                .Returns(_column);
        }

        [Test]
        public void TestExecuteShouldSetImageIfColumnDataTypeIsImage()
        {
            SetUpColumn(typeof(BitmapImage), SemanticType.Unknown);
            _handler.Execute(new AutoLayoutColumnCommand(1));
            Assert.That(_layout.ShapeColumn, Is.EqualTo(_column));
        }

        [Test]
        public void TestExecuteShouldSetLinkIfSemanticTypeIsUri()
        {
            SetUpColumn(typeof(string), SemanticType.Uri);
            _handler.Execute(new AutoLayoutColumnCommand(1));
            Assert.That(_layout.LinkColumn, Is.EqualTo(_column));
        }

        [Test]
        public void TestExecuteShouldSetXAxisIfNotSet()
        {
            _layout.XAxisColumn = null;
            _handler.Execute(new AutoLayoutColumnCommand(1));
            Assert.That(_layout.XAxisColumn, Is.EqualTo(_column));
        }

        [Test]
        public void TestExecuteShouldSetYAxisIfNotSet()
        {
            _layout.YAxisColumn = null;
            _handler.Execute(new AutoLayoutColumnCommand(1));
            Assert.That(_layout.YAxisColumn, Is.EqualTo(_column));
        }

        [Test]
        public void TestExecuteShouldSetColorIfNotSet()
        {
            _layout.ColorColumn = null;
            _handler.Execute(new AutoLayoutColumnCommand(1));
            Assert.That(_layout.ColorColumn, Is.EqualTo(_column));
        }

        [Test]
        public void TestExecuteShouldSetSizeIfNotSet()
        {
            _layout.SizeColumn = null;
            _handler.Execute(new AutoLayoutColumnCommand(1));
            Assert.That(_layout.SizeColumn, Is.EqualTo(_column));
        }

        [Test]
        public void TestExecuteShouldSetLabelIfNotSet()
        {
            _layout.LabelColumn = null;
            _handler.Execute(new AutoLayoutColumnCommand(1));
            Assert.That(_layout.LabelColumn, Is.EqualTo(_column));
        }
    }
}
