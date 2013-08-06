using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DataExplorer.Presentation.Core;
using NUnit.Framework;

namespace DataExplorer.Tests.Presentation.Core
{
    [TestFixture, RequiresSTA]
    public class DependencyPropertyServiceTests
    {
        private DependencyPropertyService _service;
        private DependencyObject _dependencyObject;
        private DependencyProperty _dependencyProperty;

        [TestFixtureSetUp]
        public void SetUpTestFixture()
        {
            _dependencyProperty = DependencyProperty.Register(
                "TestProperty",
                typeof(object),
                typeof(FrameworkElement),
                new PropertyMetadata());
        }

        [SetUp]
        public void SetUp()
        {
            _dependencyObject = new FrameworkElement();
            _service = new DependencyPropertyService();
        }

        [Test]
        public void TestSetSourceShouldSetSource()
        {
            _service.SetSource(_dependencyObject);
            Assert.That(_service.GetSource(), Is.EqualTo(_dependencyObject));
        }

        [Test]
        public void TestGetValueShouldGetValue()
        {
            _service.SetSource(_dependencyObject);
            _dependencyObject.SetValue(_dependencyProperty, "TestValue");
            var result = _service.GetValue(_dependencyProperty);
            Assert.That(result, Is.EqualTo("TestValue"));
        }

        [Test]
        public void TestSetValueShouldSetValue()
        {
            _service.SetSource(_dependencyObject);
            _service.SetValue(_dependencyProperty, "TestValue");
            var result = _dependencyObject.GetValue(_dependencyProperty);
            Assert.That(result, Is.EqualTo("TestValue"));
        }
    }
}
