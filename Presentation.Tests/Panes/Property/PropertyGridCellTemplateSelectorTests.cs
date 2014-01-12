using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DataExplorer.Presentation.Panes.Property;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Tests.Presentation.Panes.Property
{
    [TestFixture]
    public class PropertyGridCellTemplateSelectorTests
    {
        private PropertyGridCellTemplateSelector _selector;
        private Mock<IPropertyViewModel> _mockViewModel;
        private DependencyObject _container;
        private DataTemplate _labelTemplate;
        private DataTemplate _linkTemplate;

        [SetUp]
        public void SetUp()
        {
            _mockViewModel = new Mock<IPropertyViewModel>();
            _container = new DependencyObject();
            _labelTemplate = new DataTemplate();
            _linkTemplate = new DataTemplate();
            
            _selector = new PropertyGridCellTemplateSelector();

            _selector.LabelTemplate = _labelTemplate;
            _selector.LinkTemplate = _linkTemplate;
        }

        [Test]
        public void TestSelectTemplateShouldReturnLabelTemplateIfItemIsNotPropertyViewModel()
        {
            var item = new object();
            var result = _selector.SelectTemplate(item, _container);
            Assert.That(result, Is.EqualTo(_labelTemplate));
        }

        [Test]
        public void TestSelectTemplateShouldReturnLabelTemplateIfItemIsNotLink()
        {
            _mockViewModel.Setup(p => p.IsLink).Returns(false);
            var result = _selector.SelectTemplate(_mockViewModel.Object, _container);
            Assert.That(result, Is.EqualTo(_labelTemplate));
        }

        [Test]
        public void TestSelectTemplateShouldReturnLinkTemplateIfItemIsLink()
        {
            _mockViewModel.Setup(p => p.IsLink).Returns(true);
            var result = _selector.SelectTemplate(_mockViewModel.Object, _container);
            Assert.That(result, Is.EqualTo(_labelTemplate));
        }
    }
}
