using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Rows;
using DataExplorer.Tests.Domain.Rows;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace DataExplorer.Specs.Rows
{
    [Binding]
    public class RowSteps
    {
        private readonly Context _context;

        public RowSteps(Context context)
        {
            _context = context;
        }

        [Given(@"a row")]
        public void GivenARow()
        {
            var row = new RowBuilder().Build();
            _context.Row = row;
            _context.DataContext.Rows.Add(row);
        }

        [Then(@"the row should be added to the repository")]
        public void ThenTheRowShouldBeAddedToTheRepository()
        {
            Assert.That(_context.DataContext.Rows.Any(p => p == _context.Row), Is.True);
        }

        [Then(@"the row should be removed from the repository")]
        public void ThenTheRowShouldBeRemovedFromTheRepository()
        {
            Assert.That(_context.DataContext.Rows.Any(p => p == _context.Row), Is.False);
        }
    }
}
