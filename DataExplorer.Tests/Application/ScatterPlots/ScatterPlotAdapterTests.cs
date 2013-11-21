using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.ScatterPlots;
using DataExplorer.Domain.ScatterPlots;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Tests.Application.ScatterPlots
{
    [TestFixture]
    public class ScatterPlotAdapterTests
    {
        private ScatterPlotAdapter _adapter;
        private Mock<IScatterPlot> _mockScatterPlot;

        [SetUp]
        public void SetUp()
        {
            _adapter = new ScatterPlotAdapter();
            _mockScatterPlot = new Mock<IScatterPlot>();
        }

        [Test]
        public void TestAdaptShouldAdaptScatterPlotToDto()
        {
            var plot = new Plot() { Id = 1, X = 2d, Y = 3d };
            var plots = new List<Plot> { plot };
            _mockScatterPlot.Setup(p => p.GetPlots()).Returns(plots);
            var dtos = _adapter.Adapt(_mockScatterPlot.Object.GetPlots());
            Assert.That(dtos.Single().Id, Is.EqualTo(1));
            Assert.That(dtos.Single().X, Is.EqualTo(2d));
            Assert.That(dtos.Single().Y, Is.EqualTo(3d));
        }
    }
}
