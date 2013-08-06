using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.ScatterPlot;
using DataExplorer.Domain.ScatterPlot;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Tests.Application.ScatterPlot
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
            var plot = new Plot() { X = 1, Y = 2 };
            var plots = new List<Plot> { plot };
            _mockScatterPlot.Setup(p => p.GetPlots()).Returns(plots);
            var dtos = _adapter.Adapt(_mockScatterPlot.Object.GetPlots());
            Assert.That(dtos.Single().X, Is.EqualTo(1));
            Assert.That(dtos.Single().Y, Is.EqualTo(2));
        }
    }
}
