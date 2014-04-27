using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Views;
using DataExplorer.Domain.Layouts;
using DataExplorer.Domain.Tests.Views.ScatterPlots;
using DataExplorer.Domain.Views.ScatterPlots;
using Moq;

namespace DataExplorer.Application.Tests.Layouts.Base.Queries
{
    public class BaseGetLayoutSortOrderQueryHandlerTests
    {
        protected Mock<IViewRepository> _mockRepository;
        protected ScatterPlot _scatterPlot;
        protected ScatterPlotLayout _layout;
        
        public virtual void SetUp()
        {
            _layout = new ScatterPlotLayoutBuilder()
                .Build();
            _scatterPlot = new ScatterPlotBuilder()
                .WithLayout(_layout)
                .Build();

            _mockRepository = new Mock<IViewRepository>();
            _mockRepository.Setup(p => p.Get<ScatterPlot>())
                .Returns(_scatterPlot);
        }
    }
}
