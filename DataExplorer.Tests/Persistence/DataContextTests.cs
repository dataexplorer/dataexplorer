using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Projects;
using DataExplorer.Domain.Rows;
using DataExplorer.Domain.ScatterPlots;
using DataExplorer.Persistence;
using NUnit.Framework;

namespace DataExplorer.Tests.Persistence
{
    [TestFixture]
    public class DataContextTests
    {
        private DataContext _dataContext;

        [SetUp]
        public void SetUp()
        {
            _dataContext = new DataContext();
        }

        [Test]
        public void TestConstructorShouldCreateDefaults()
        {
            Assert.That(_dataContext.Columns, Is.Not.Null);
            Assert.That(_dataContext.Rows, Is.Not.Null);
            Assert.That(_dataContext.ScatterPlot, Is.Not.Null);
        }

        [Test]
        public void TestSetProjectShouldSetDataProperties()
        {
            var columns = new List<Column>();
            var rows = new List<Row>();
            var scatterPlot = new ScatterPlot();
            var project = new Project() { Columns = columns, Rows = rows, ScatterPlot = scatterPlot };
            _dataContext.SetProject(project);
            Assert.That(_dataContext.Columns, Is.EqualTo(columns));
            Assert.That(_dataContext.Rows, Is.EqualTo(rows));
            Assert.That(_dataContext.ScatterPlot, Is.EqualTo(scatterPlot));
        }

        [Test]
        public void TestClearShouldClearDataProperties()
        {
            _dataContext.Clear();
            Assert.That(_dataContext.Columns.Count(), Is.EqualTo(0));
            Assert.That(_dataContext.Rows.Count(), Is.EqualTo(0));
            //Assert.That(_dataContext.ScatterPlot, Is.EqualTo(new ScatterPlot()));
        }
    }
}
