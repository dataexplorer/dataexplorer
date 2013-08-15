using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.ScatterPlots;
using NUnit.Framework;

namespace DataExplorer.Tests.Domain.ScatterPlots
{
    [TestFixture]
    public class ScatterPlotLayoutTests
    {
        private ScatterPlotLayout _layout;
        private Column _xAxisColumn;

        [SetUp]
        public void SetUp()
        {
            _xAxisColumn = new Column(1, 0, "X");
            _layout = new ScatterPlotLayout()
            {
                XAxisColumn = _xAxisColumn
            };
        }

        [Test]
        public void TestGetXAxisColumnShouldReturnXAxisColumn()
        {
            var result = _layout.XAxisColumn;
            Assert.That(result, Is.EqualTo(_xAxisColumn));
        }

        [Test]
        public void TestSetXAxisColumnShouldSetXAxisColumn()
        {
            var column = new Column(10, 9, "X2");
            _layout.XAxisColumn = column;
            Assert.That(_layout.XAxisColumn, Is.EqualTo(column));
        }
    }
}
