using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Core.Events;
using DataExplorer.Application.Views;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Tests.Columns;
using DataExplorer.Domain.Tests.Views.ScatterPlots;
using DataExplorer.Domain.Views.ScatterPlots;
using Moq;

namespace DataExplorer.Application.Tests.Layouts.Base.Commands
{
    public class BaseUnsetLayoutColumnCommandHandlerTests
    {
        protected Mock<IViewRepository> _mockViewRepository;
        protected Mock<IEventBus> _mockEventBus;
        protected ScatterPlot _view;
        protected ScatterPlotLayout _layout;
        protected Column _column;

        public virtual void SetUp()
        {
            _column = new ColumnBuilder().Build();

            _layout = new ScatterPlotLayoutBuilder()
                .WithLinkColumn(_column)
                .Build();
            _view = new ScatterPlotBuilder()
                .WithLayout(_layout)
                .Build();

            _mockViewRepository = new Mock<IViewRepository>();
            _mockViewRepository.Setup(p => p.Get<ScatterPlot>())
                .Returns(_view);

            _mockEventBus = new Mock<IEventBus>();
        }
    }
}
