using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Filters;
using DataExplorer.Presentation.Panes.Filter;
using DataExplorer.Presentation.Panes.Filter.BooleanFilters;
using NUnit.Framework;

namespace DataExplorer.Presentation.Tests.Panes.Filter
{
    [TestFixture]
    public class FilterViewModelFactoryTests
    {
        private FilterViewModelFactory _factory;

        [SetUp]
        public void SetUp()
        {
            _factory = new FilterViewModelFactory();
        }

        [Test]
        public void TestCreateShouldCreateBooleanFilterFactory()
        {
            var filter = new BooleanFilter(null, true, true, true);
            var result = _factory.Create(filter);
            Assert.That(result, Is.TypeOf<BooleanFilterViewModel>());
            Assert.That(result.Filter, Is.EqualTo(filter));
        }
    }
}
