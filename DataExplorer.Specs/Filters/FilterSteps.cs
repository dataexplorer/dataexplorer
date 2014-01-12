using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace DataExplorer.Specs.Filters
{
    [Binding]
    public class FilterSteps
    {
        private readonly AppContext _appContext;

        public FilterSteps(AppContext appContext)
        {
            _appContext = appContext;
        }

        [Then(@"the filter should be added to the repository")]
        public void ThenTheFilterShouldBeAddedToTheRepository()
        {
            Assert.That(_appContext.DataContext.Filters.Any(p => p == _appContext.Filter), Is.True);
        }

    }
}
