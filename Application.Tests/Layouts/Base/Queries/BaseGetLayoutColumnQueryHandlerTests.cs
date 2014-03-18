using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DataExplorer.Application.Columns;
using DataExplorer.Application.Core.Queries;
using DataExplorer.Application.Layouts;
using DataExplorer.Application.Views;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Tests.Columns;
using DataExplorer.Domain.Tests.Views.ScatterPlots;
using DataExplorer.Domain.Views.ScatterPlots;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Application.Tests.Layouts.Base.Queries
{
    public class BaseGetLayoutColumnQueryHandlerTests
    {
        protected Mock<IViewRepository> _mockRepository;
        protected Mock<IColumnAdapter> _mockAdapter;
        protected ScatterPlot _scatterPlot;
        protected ScatterPlotLayout _layout;
        protected Column _column;
        protected ColumnDto _columnDto;

        public virtual void SetUp()
        {
            _columnDto = new ColumnDto();
            _column = new ColumnBuilder().Build();
            _layout = new ScatterPlotLayoutBuilder()
                .Build();
            _scatterPlot = new ScatterPlotBuilder()
                .WithLayout(_layout)
                .Build();

            _mockRepository = new Mock<IViewRepository>();
            _mockRepository.Setup(p => p.Get<ScatterPlot>())
                .Returns(_scatterPlot);

            _mockAdapter = new Mock<IColumnAdapter>();
            _mockAdapter.Setup(p => p.Adapt(_column))
                .Returns(_columnDto);
        }
    }
}
