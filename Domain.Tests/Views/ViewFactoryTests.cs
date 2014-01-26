using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Tests.Views.ScatterPlots;
using DataExplorer.Domain.Views;
using DataExplorer.Domain.Views.ScatterPlots;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Domain.Tests.Views
{
    [TestFixture]
    public class ViewFactoryTests
    {
        private ViewFactory _factory;
        private Mock<IScatterPlotFactory> _mockScatterPlotFactory;
        private ScatterPlot _scatterPlot;

        [SetUp]
        public void SetUp()
        {
            _scatterPlot = new ScatterPlotBuilder().Build();

            _mockScatterPlotFactory = new Mock<IScatterPlotFactory>();
            _mockScatterPlotFactory.Setup(p => p.Create())
                .Returns(_scatterPlot);

            _factory = new ViewFactory(
                _mockScatterPlotFactory.Object);
        }

        [Test]
        public void TestCreateShouldCreateScatterPlot()
        {
            var result = _factory.Create<ScatterPlot>();
            Assert.That(result, Is.EqualTo(_scatterPlot));
        }
    }
}
