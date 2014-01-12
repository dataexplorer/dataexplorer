using System;
using System.Collections.Generic;
using DataExplorer.Application;
using DataExplorer.Domain.Views;
using DataExplorer.Domain.Views.ScatterPlots;
using DataExplorer.Persistence.Views;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Persistence.Tests.Views
{
    [TestFixture]
    public class ViewRepositoryTests
    {
        private ViewRepository _repository;
        private Mock<IDataContext> _mockViewContext;
        private Dictionary<Type, IView> _views;

        [SetUp]
        public void SetUp()
        {
            _views = new Dictionary<Type, IView>();
            _mockViewContext = new Mock<IDataContext>();
            _mockViewContext.Setup(p => p.Views).Returns(_views);
            _repository = new ViewRepository(_mockViewContext.Object);
        }

        [Test]
        public void GetScatterPlotReturnsScatterPlot()
        {
            var scatterPlot = new ScatterPlot();
            _views.Add(scatterPlot.GetType(), scatterPlot);
            var result = _repository.Get<ScatterPlot>();
            Assert.That(result, Is.EqualTo(scatterPlot));
        }

        [Test]
        public void AddViewShouldAddView()
        {
            var view = new ScatterPlot();
            _repository.Set<ScatterPlot>(view);
            Assert.That(_views.ContainsKey(view.GetType()));
            Assert.That(_views.ContainsValue(view));
        }
    }
}
