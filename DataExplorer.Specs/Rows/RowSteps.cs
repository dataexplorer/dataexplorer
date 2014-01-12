using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Rows;
using DataExplorer.Domain.Tests.Rows;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace DataExplorer.Specs.Rows
{
    [Binding]
    public class RowSteps
    {
        private readonly AppContext _appContext;

        public RowSteps(AppContext appContext)
        {
            _appContext = appContext;
        }

        [Given(@"a row")]
        public void GivenARow()
        {
            var row = new RowBuilder().Build();
            _appContext.Row = row;
            _appContext.DataContext.Rows.Add(row);
        }

        [Then(@"the row should be added to the repository")]
        public void ThenTheRowShouldBeAddedToTheRepository()
        {
            Assert.That(_appContext.DataContext.Rows.Any(p => p == _appContext.Row), Is.True);
        }

        [Then(@"the row should be removed from the repository")]
        public void ThenTheRowShouldBeRemovedFromTheRepository()
        {
            Assert.That(_appContext.DataContext.Rows.Any(p => p == _appContext.Row), Is.False);
        }
    }
}
