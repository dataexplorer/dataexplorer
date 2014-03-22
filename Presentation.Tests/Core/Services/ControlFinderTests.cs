using System;
using System.Windows;
using System.Windows.Controls;
using DataExplorer.Presentation.Core.Services;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Presentation.Tests.Core.Services
{
    [TestFixture]
    public class ControlFinderTests
    {
        private ControlFinder _finder;
        private Mock<IVisualTreeHelper> _mockHelper;
        private Window _window;
        private FakeControl _control;

        [SetUp]
        public void SetUp()
        {
            _window = new Window();
            _control = new FakeControl();
            
            _mockHelper = new Mock<IVisualTreeHelper>();
            _mockHelper.Setup(p => p.GetChildrenCount(_window))
                .Returns(1);
            _mockHelper.Setup(p => p.GetParent(_control))
                .Returns(_window);
            _mockHelper.Setup(p => p.GetChild(_window, 0))
                .Returns(_control);

            _finder = new ControlFinder(_mockHelper.Object);
        }

        [Test]
        [STAThread]
        public void TestFindAncestorShouldReturnNullIfCurrentIsNull()
        {
            var result = _finder.FindAncestor<FakeControl>(null);
            Assert.That(result, Is.Null);
        }

        [Test]
        [STAThread]
        public void TestFindAncestorShouldReturnCurrentIfControlIsMatchingType()
        {
            var result = _finder.FindAncestor<FakeControl>(_control);
            Assert.That(result, Is.EqualTo(_control));
        }

        [Test]
        [STAThread]
        public void TestFindAncestorShouldReturnNullIfParentIsNull()
        {
            _mockHelper.Setup(p => p.GetParent(_control)).Returns((Window) null);
            var result = _finder.FindAncestor<Window>(_control);
            Assert.That(result, Is.Null);
        }

        [Test]
        [STAThread]
        public void TestFindAncestorShouldReturnParentIfParentIsMatchingType()
        {
            var result = _finder.FindAncestor<Window>(_control);
            Assert.That(result, Is.EqualTo(_window));
        }

        [Test]
        [STAThread]
        public void TestFindDecendantShouldReturnNullIfParentIsNull()
        {
            var result = _finder.FindDecendant<FakeControl>(null);
            Assert.That(result, Is.Null);
        }

        [Test]
        [STAThread]
        public void TestFindDecendantShouldReturnControlIfParentIsMatchingType()
        {
            var result = _finder.FindDecendant<FakeControl>(_control);
            Assert.That(result, Is.EqualTo(_control));
        }

        [Test]
        [STAThread]
        public void TestFindDecendantShouldReturnNullIfParentHasNoChildren()
        {
            _mockHelper.Setup(p => p.GetChildrenCount(_window)).Returns(0);
            var result = _finder.FindDecendant<FakeControl>(_window);
            Assert.That(result, Is.Null);
        }

        [Test]
        [STAThread]
        public void TestFindDecendantShouldReturnNullIfMatchingChildIsNotFound()
        {
            _mockHelper.Setup(p => p.GetChild(_window, 0)).Returns(new Button());
            var result = _finder.FindDecendant<FakeControl>(_window);
            Assert.That(result, Is.Null);
        }

        [Test]
        [STAThread]
        public void TestFindDecendantShouldReturnControlIfParentContainsMatchingControl()
        {
            var result = _finder.FindDecendant<FakeControl>(_window);
            Assert.That(result, Is.EqualTo(_control));
        }
    }
}
