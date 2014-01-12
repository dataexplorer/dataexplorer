using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Tests.Columns;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace DataExplorer.Specs.Columns
{
    [Binding]
    public class ColumnSteps
    {
        private readonly AppContext _appContext;

        public ColumnSteps(AppContext appContext)
        {
            _appContext = appContext;
        }

        [Given(@"a column")]
        public void GivenAColumn()
        {
            var column = new ColumnBuilder().Build();
            _appContext.Column = column;
            _appContext.DataContext.Columns.Add(column);
        }

        [Then(@"the column should be added to the repository")]
        public void ThenTheColumnShouldBeAddedToTheRepository()
        {
            Assert.That(_appContext.DataContext.Columns.Any(p => p == _appContext.Column), Is.True);
        }

        [Then(@"the column should be removed from the repository")]
        public void ThenTheColumnShouldBeRemovedFromTheRepository()
        {
            Assert.That(_appContext.DataContext.Columns.Any(p => p == _appContext.Column), Is.False);
        }
    }
}
