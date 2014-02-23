using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Layouts.Size.Queries;
using DataExplorer.Application.Views;
using DataExplorer.Domain.Tests.Views.ScatterPlots;
using DataExplorer.Domain.Views.ScatterPlots;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Application.Tests.Layouts.Size.Queries
{
    [TestFixture]
    public class GetLowerSizeQueryHandlerTests
    {
        private GetLowerSizeQueryHandler _handler;
        private Mock<IViewRepository> _mockRepository;
        private ScatterPlot _scatterPlot;
        private ScatterPlotLayout _layout;
        
        [SetUp]
        public void SetUp()
        {
            _layout = new ScatterPlotLayoutBuilder()
                .WithLowerSize(0.1d)
                .Build();
            _scatterPlot = new ScatterPlotBuilder()
                .WithLayout(_layout)
                .Build();

            _mockRepository = new Mock<IViewRepository>();
            _mockRepository.Setup(p => p.Get<ScatterPlot>())
                .Returns(_scatterPlot);

            _handler = new GetLowerSizeQueryHandler(
                _mockRepository.Object);
        }

        [Test]
        public void TestExecuteShouldReturnColorColumn()
        {
            var result = _handler.Execute(new GetLowerSizeQuery());
            Assert.That(result, Is.EqualTo(0.1d));
        }
    }
}
