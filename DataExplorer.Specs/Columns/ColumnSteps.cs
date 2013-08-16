using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Columns;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace DataExplorer.Specs.Columns
{
    [Binding]
    public class ColumnSteps
    {
        private readonly Context _context;

        public ColumnSteps(Context context)
        {
            _context = context;
        }

        [Given(@"a column")]
        public void GivenAColumn()
        {
            var column = new Column(1, 0, "Test");
            _context.Column = column;
            _context.DataContext.Columns.Add(column);
        }

        [Then(@"the column is added to the repository")]
        public void ThenTheColumnIsAddedToTheRepository()
        {
            Assert.That(_context.DataContext.Columns.Any(p => p == _context.Column), Is.True);
        }

        [Then(@"the column is removed from the repository")]
        public void ThenTheColumnIsRemovedFromTheRepository()
        {
            Assert.That(_context.DataContext.Columns.Any(p => p == _context.Column), Is.False);
        }
    }
}
