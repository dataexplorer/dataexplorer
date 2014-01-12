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
        private readonly AppContext _appContext;

        public SourceSteps(AppContext appContext)
        {
            _appContext = appContext;
        }

        [Given(@"a CSV file source")]
        public void GivenACSVFileSource()
        {
            var source = new CsvFileSource();
            _appContext.CsvFileSource = source;
            _appContext.DataContext.Sources.Add(source.GetType(), source);
        }


        [Then(@"the source should be added to the repository")]
        public void ThenTheSourceShouldBeAddedToTheRepository()
        {
            Assert.That(_appContext.DataContext.Sources.ContainsValue(_appContext.CsvFileSource), Is.True);
        }

        [Then(@"the source should be removed from the repository")]
        public void ThenTheSourceShouldBeRemovedFromTheRepository()
        {
            Assert.That(_appContext.DataContext.Sources.ContainsValue(_appContext.CsvFileSource), Is.False);
        }
    }
}
