using System.Collections.Generic;
using System.Linq;
using DataExplorer.Application.Views.ScatterPlots;
using DataExplorer.Domain.Colors;
using DataExplorer.Domain.Views.ScatterPlots;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Application.Tests.Views.ScatterPlots
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
            var plot = new Plot()
            {
                Id = 1,
                X = 2d,
                Y = 3d,
                Color = new Color(0, 0, 0),
                Size = 4d,
                Label = "Test"
            };
            var plots = new List<Plot> { plot };
            _mockScatterPlot.Setup(p => p.GetPlots()).Returns(plots);
            var dtos = _adapter.Adapt(_mockScatterPlot.Object.GetPlots());
            Assert.That(dtos.Single().Id, Is.EqualTo(1));
            Assert.That(dtos.Single().X, Is.EqualTo(2d));
            Assert.That(dtos.Single().Y, Is.EqualTo(3d));
            Assert.That(dtos.Single().Color, Is.EqualTo(new Color(0, 0, 0)));
            Assert.That(dtos.Single().Size, Is.EqualTo(4d));
            Assert.That(dtos.Single().Label, Is.EqualTo("Test"));
        }
    }
}
