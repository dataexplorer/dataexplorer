using System.Collections.Generic;
using System.Windows.Media;
using DataExplorer.Presentation.Core.Canvas;
using DataExplorer.Presentation.Core.Services;
using NUnit.Framework;

namespace DataExplorer.Presentation.Tests.Core.Services
{
    [TestFixture, RequiresSTA]
    public class VisualServiceTests
    {
        private VisualService _service;
        private CanvasControl _control;
        private Visual _visual;
        private List<Visual> _visuals;
            
        [SetUp]
        public void SetUp()
        { 
            // TODO: Should I replace this data with a builder in the test methods?
            _visual = new FakeVisual();
            _visuals = new List<Visual> { _visual };
            _control = new CanvasControl();
            _service = new VisualService();

            _service.SetSource(_control);
        }

        [Test]
        public void TestSetSourceShouldSetSource()
        {
            _service.SetSource(_control);
            var result = _service.GetSource();
            Assert.That(result, Is.EqualTo(_control));
        }

        [Test]
        public void TestGetVisualsCountShouldInitiallyBeZero()
        {
            var result = _service.GetVisualsCount();
            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void TestGetVisualsShouldReturnCountOfVisuals()
        {
            _service.Add(_visuals);
            var result = _service.GetVisualsCount();
            Assert.That(result, Is.EqualTo(1));
        }

        [Test]
        public void TestGetVisualShouldReturnVisual()
        {
            _service.Add(_visuals);
            var visualResult = _service.GetVisual(0);
            Assert.That(visualResult, Is.EqualTo(_visual));
        }

        [Test]
        public void TestAddShouldAddVisuals()
        {
            _service.Add(_visuals);
            var countResult = _service.GetVisualsCount();
            var visualResult = _service.GetVisual(0);
            Assert.That(countResult, Is.EqualTo(1));
            Assert.That(visualResult, Is.EqualTo(_visual));
        }

        [Test]
        public void TestClearShouldClearVisuals()
        {
            _service.Add(_visuals);
            var result1 = _service.GetVisualsCount();
            Assert.That(result1, Is.EqualTo(1));
            _service.Clear();
            var result = _service.GetVisualsCount();
            Assert.That(result, Is.EqualTo(0));
        }
    }
}
