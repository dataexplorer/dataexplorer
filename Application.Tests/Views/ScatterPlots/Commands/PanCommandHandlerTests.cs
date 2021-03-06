﻿using System.Windows;
using DataExplorer.Application.Views;
using DataExplorer.Application.Views.ScatterPlots.Commands;
using DataExplorer.Domain.Core.Events;
using DataExplorer.Domain.Views;
using DataExplorer.Domain.Views.ScatterPlots;
using DataExplorer.Domain.Views.ScatterPlots.Events;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Application.Tests.Views.ScatterPlots.Commands
{
    [TestFixture]
    public class PanCommandHandlerTests
    {
        private PanCommandHandler _handler;
        private Mock<IViewRepository> _mockRepository;
        private ScatterPlot _scatterPlot;
        private Rect _viewExtent;
        private Vector _vector;

        [SetUp]
        public void SetUp()
        {
            _vector = new Vector(0.25, 0.5);
            _viewExtent = new Rect(0, 0, 1, 1);
            _scatterPlot = new ScatterPlot(null, _viewExtent, null);
            _mockRepository = new Mock<IViewRepository>();
            _mockRepository.Setup(p => p.Get<ScatterPlot>()).Returns(_scatterPlot);
            _handler = new PanCommandHandler(_mockRepository.Object);
        }

        [Test]
        public void TestPanShouldPan()
        {
            _handler.Execute(new PanCommand(_vector));
            var newViewExtent = _scatterPlot.GetViewExtent();
            Assert.That(newViewExtent.X, Is.EqualTo(0.25));
            Assert.That(newViewExtent.Y, Is.EqualTo(0.5));
        }

        [Test]
        public void TestPanShouldRaiseScatterPlotChangedEvent()
        {
            var wasRaised = false;
            DomainEvents.Register<ScatterPlotChangedEvent>(p => { wasRaised = true; });
            _handler.Execute(new PanCommand(_vector));
            Assert.That(wasRaised, Is.True);
            DomainEvents.ClearHandlers();
        }
    }
}
