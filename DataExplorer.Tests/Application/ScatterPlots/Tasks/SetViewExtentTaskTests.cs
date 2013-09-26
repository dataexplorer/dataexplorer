using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DataExplorer.Application.ScatterPlots.Tasks;
using DataExplorer.Domain.ScatterPlots;
using DataExplorer.Domain.Views;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Tests.Application.ScatterPlots.Tasks
{
    [TestFixture]
    public class SetViewExtentTaskTests
    {
        private SetViewExtentTask _task;
        private Mock<IViewRepository> _mockRepository;
        private ScatterPlot _scatterPlot;
        private Rect _viewExtent;

        [SetUp]
        public void SetUp()
        {
            _viewExtent = new Rect();
            _scatterPlot = new ScatterPlot();
            _mockRepository = new Mock<IViewRepository>();
            _mockRepository.Setup(p => p.Get<ScatterPlot>()).Returns(_scatterPlot);
            _task = new SetViewExtentTask(_mockRepository.Object);
        }

        [Test]
        public void TestSetViewExtentShouldSetViewExtent()
        {
            _task.SetViewExtent(_viewExtent);
            Assert.That(_scatterPlot.GetViewExtent(), Is.EqualTo(_viewExtent));
        }
    }
}
