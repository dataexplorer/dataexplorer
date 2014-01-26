using System;
using System.Collections.Generic;
using DataExplorer.Application;
using DataExplorer.Domain.Tests.Views;
using DataExplorer.Domain.Tests.Views.ScatterPlots;
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
        private Mock<IDataContext> _mockContext;
        private Mock<IViewFactory> _mockFactory;
        private Dictionary<Type, View> _views;
        private FakeView _view;

        [SetUp]
        public void SetUp()
        {
            _views = new Dictionary<Type, View>();
            _view = new FakeView();

            _mockContext = new Mock<IDataContext>();
            _mockContext.Setup(p => p.Views).Returns(_views);
            
            _mockFactory = new Mock<IViewFactory>();
            _mockFactory.Setup(p => p.Create<FakeView>())
                .Returns(_view);

            _repository = new ViewRepository(
                _mockContext.Object,
                _mockFactory.Object);
        }

        [Test]
        public void GetShouldCreateANewViewIfViewTypeDoesNotExist()
        {
            var result = _repository.Get<FakeView>();
            Assert.That(result, Is.EqualTo(_view));
        }

        [Test]
        public void GetScatterPlotReturnsScatterPlot()
        {
            _views.Add(_view.GetType(), _view);
            var result = _repository.Get<FakeView>();
            Assert.That(result, Is.EqualTo(_view));
        }

        [Test]
        public void AddViewShouldAddView()
        {
            _repository.Set(_view);
            Assert.That(_views.ContainsKey(_view.GetType()));
            Assert.That(_views.ContainsValue(_view));
        }
    }
}
