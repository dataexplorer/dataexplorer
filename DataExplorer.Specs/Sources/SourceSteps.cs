using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataExplorer.Domain.Sources;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace DataExplorer.Specs.Sources
{
    [Binding]
    public class SourceSteps
    {
        private readonly Context _context;

        public SourceSteps(Context context)
        {
            _context = context;
        }

        [Given(@"a CSV file source")]
        public void GivenACSVFileSource()
        {
            var source = new CsvFileSource();
            _context.CsvFileSource = source;
            _context.DataContext.Sources.Add(source.GetType(), source);
        }


        [Then(@"the source should be added to the repository")]
        public void ThenTheSourceShouldBeAddedToTheRepository()
        {
            Assert.That(_context.DataContext.Sources.ContainsValue(_context.CsvFileSource), Is.True);
        }

        [Then(@"the source should be removed from the repository")]
        public void ThenTheSourceShouldBeRemovedFromTheRepository()
        {
            Assert.That(_context.DataContext.Sources.ContainsValue(_context.CsvFileSource), Is.False);
        }
    }
}
