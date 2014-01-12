using DataExplorer.Application;
using DataExplorer.Presentation.Panes.Property;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Presentation.Tests.Panes.Property
{
    [TestFixture]
    public class PropertyViewModelTests
    {
        private PropertyViewModel _viewModel;
        private Mock<IProcess> _mockProcess;
        private string _name;
        private string _value;

        [SetUp]
        public void SetUp()
        {
            _name = "Name";
            _value = "Value";

            _mockProcess = new Mock<IProcess>();

            _viewModel = new PropertyViewModel(
                _name,
                _value,
                _mockProcess.Object);
        }

        [Test]
        public void TestNameShouldReturnName()
        {
            var result = _viewModel.Name;
            Assert.That(result, Is.EqualTo(_name));
        }

        [Test]
        public void TestValueShouldReturnValue()
        {
            var result = _viewModel.Value;
            Assert.That(result, Is.EqualTo(_value));
        }

        [Test]
        public void TestIsLinkShouldReturnFalseIfNotLink()
        {
            var result = _viewModel.IsLink;
            Assert.That(result, Is.False);
        }

        [Test]
        public void TestIsLinkShouldReturnTrueIfLink()
        {
            _viewModel = new PropertyViewModel(_name, "http://www.test.com", _mockProcess.Object);
            var result = _viewModel.IsLink;
            Assert.That(result, Is.True);
        }

        [Test]
        public void TestHandleLinkClickShouldRaisePropertyLinkClickedEvent()
        {
            _viewModel.HandleLinkClick();
            _mockProcess.Verify(p => p.Start(_value), Times.Once());
        }
    }
}
