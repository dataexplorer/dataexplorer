using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DataExplorer.Presentation.Panes.Filter;
using DataExplorer.Presentation.Panes.Filter.BooleanFilters;
using NUnit.Framework;

namespace DataExplorer.Presentation.Tests.Panes.Filter
{
    [TestFixture]
    public class FilterDataTemplateSelectorTests
    {
        private FilterDataTemplateSelector _selector;
        private DataTemplate _dataTemplate;

        [SetUp]
        public void SetUp()
        {
            _dataTemplate = new DataTemplate();

            _selector = new FilterDataTemplateSelector();
        }

        [Test]
        public void TestSelectTemplateShouldReturnBooleanFilterDataTemplate()
        {
            _selector.BooleanFilterDataTemplate = _dataTemplate;
            var result = _selector.SelectTemplate(new BooleanFilterViewModel(null, null), null);
            Assert.That(result, Is.EqualTo(_dataTemplate));
        }
    }
}
