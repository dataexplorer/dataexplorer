using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using DataExplorer.Presentation.Core;
using DataExplorer.Presentation.Core.Services;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Tests.Presentation.Core.Services
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
            _mockHelper.Setup(p => p.GetChildrenCount(_window)).Returns(1);
            _mockHelper.Setup(p => p.GetChild(_window, 0)).Returns(_control);

            _finder = new ControlFinder(_mockHelper.Object);
        }

        [Test]
        [STAThread]
        public void TestFindShouldReturnNullIfParentIsNull()
        {
            var result = _finder.Find<FakeControl>(null);
            Assert.That(result, Is.Null);
        }

        [Test]
        [STAThread]
        public void TestFindShouldReturnControlIfParentIsMatchingType()
        {
            var result = _finder.Find<FakeControl>(_control);
            Assert.That(result, Is.EqualTo(_control));
        }

        [Test]
        [STAThread]
        public void TestFindShouldReturnNullIfParentHasNoChildren()
        {
            _mockHelper.Setup(p => p.GetChildrenCount(_window)).Returns(0);
            var result = _finder.Find<FakeControl>(_window);
            Assert.That(result, Is.Null);
        }

        [Test]
        [STAThread]
        public void TestFindShouldReturnNullIfMatchingChildIsNotFound()
        {
            _mockHelper.Setup(p => p.GetChild(_window, 0)).Returns(new Button());
            var result = _finder.Find<FakeControl>(_window);
            Assert.That(result, Is.Null);
        }

        [Test]
        [STAThread]
        public void TestFindShouldReturnControlIfParentContainsMatchingControl()
        {
            var result = _finder.Find<FakeControl>(_window);
            Assert.That(result, Is.EqualTo(_control));
        }
    }
}
