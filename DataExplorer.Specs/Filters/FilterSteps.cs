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
        private readonly Context _context;

        public FilterSteps(Context context)
        {
            _context = context;
        }

        [Then(@"the filter should be added to the repository")]
        public void ThenTheFilterShouldBeAddedToTheRepository()
        {
            Assert.That(_context.DataContext.Filters.Any(p => p == _context.Filter), Is.True);
        }

    }
}
