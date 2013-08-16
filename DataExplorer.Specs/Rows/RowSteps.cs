using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Rows;
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
            var row = new Row();
            _context.Row = row;
            _context.DataContext.Rows.Add(row);
        }

        [Then(@"the row is added to the repository")]
        public void ThenTheRowIsAddedToTheRepository()
        {
            Assert.That(_context.DataContext.Rows.Any(p => p == _context.Row), Is.True);
        }

        [Then(@"the row is removed from the repository")]
        public void ThenTheRowIsRemovedFromTheRepository()
        {
            Assert.That(_context.DataContext.Rows.Any(p => p == _context.Row), Is.False);
        }
    }
}
