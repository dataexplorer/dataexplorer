using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Columns;
using DataExplorer.Application.Core.Events;
using DataExplorer.Application.Views;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Tests.Columns;
using DataExplorer.Domain.Tests.Views.ScatterPlots;
using DataExplorer.Domain.Views.ScatterPlots;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Application.Tests.Layouts.Base.Commands
{
    public class BaseSetLayoutColumnCommandHandlerTests
    {
        protected Mock<IColumnRepository> _mockColumnRepository;
        protected Mock<IViewRepository> _mockRepository;
        protected Mock<IEventBus> _mockEventBus;
        protected ScatterPlot _scatterPlot;
        protected ScatterPlotLayout _layout;
        protected Column _column;
        protected ColumnDto _columnDto;

        public virtual void SetUp()
        {
            _columnDto = new ColumnDto() { Id = 1 };
            _column = new ColumnBuilder().Build();
            _layout = new ScatterPlotLayoutBuilder().Build();
            _scatterPlot = new ScatterPlotBuilder()
                .WithLayout(_layout)
                .Build();

            _mockColumnRepository = new Mock<IColumnRepository>();
            _mockColumnRepository.Setup(p => p.Get(_columnDto.Id))
                .Returns(_column);

            _mockRepository = new Mock<IViewRepository>();
            _mockRepository.Setup(p => p.Get<ScatterPlot>())
                .Returns(_scatterPlot);

            _mockEventBus = new Mock<IEventBus>();
        }
    }
}
