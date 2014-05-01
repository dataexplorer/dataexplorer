using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Core.Events;
using DataExplorer.Application.Views;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Tests.Views.ScatterPlots;
using DataExplorer.Domain.Views.ScatterPlots;
using Moq;

namespace DataExplorer.Application.Tests.Layouts.Base.Commands
{
    public class BaseSetLayoutSortOrderCommandHandlerTests
    {
        protected Mock<IViewRepository> _mockRepository;
        protected Mock<IEventBus> _mockEventBus;
        protected ScatterPlot _scatterPlot;
        protected ScatterPlotLayout _layout;

        public virtual void SetUp()
        {
            _layout = new ScatterPlotLayoutBuilder().Build();
            _scatterPlot = new ScatterPlotBuilder()
                .WithLayout(_layout)
                .Build();

            _mockRepository = new Mock<IViewRepository>();
            _mockRepository.Setup(p => p.Get<ScatterPlot>())
                .Returns(_scatterPlot);

            _mockEventBus = new Mock<IEventBus>();
        }
    }
}
