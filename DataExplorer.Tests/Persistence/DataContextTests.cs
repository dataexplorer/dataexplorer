using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Filters;
using DataExplorer.Domain.Projects;
using DataExplorer.Domain.Rows;
using DataExplorer.Domain.ScatterPlots;
using DataExplorer.Domain.Sources;
using DataExplorer.Domain.Views;
using DataExplorer.Persistence;
using DataExplorer.Tests.Application.Filters;
using DataExplorer.Tests.Domain.Columns;
using DataExplorer.Tests.Domain.Rows;
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
            Assert.That(_dataContext.Sources, Is.Not.Null);
            Assert.That(_dataContext.Columns, Is.Not.Null);
            Assert.That(_dataContext.Rows, Is.Not.Null);
            Assert.That(_dataContext.Filters, Is.Not.Null);
            Assert.That(_dataContext.Views, Is.Not.Null);
        }

        [Test]
        public void TestSetProjectShouldSetDataProperties()
        {
            var sources = new List<ISource>() { new CsvFileSource() };
            var columns = new List<Column> { new ColumnBuilder().Build() };
            var rows = new List<Row> { new RowBuilder().Build() };
            var filters = new List<Filter> { new FakeFilter() };
            var views = new List<IView> { new ScatterPlot() };
            var project = new Project()
            {
                Sources = sources,
                Columns = columns, 
                Rows = rows, 
                Filters = filters,
                DataViews = views
            };
            _dataContext.SetProject(project);
            Assert.That(_dataContext.Sources, Is.EqualTo(sources.ToDictionary(p => p.GetType())));
            Assert.That(_dataContext.Columns, Is.EqualTo(columns));
            Assert.That(_dataContext.Rows, Is.EqualTo(rows));
            Assert.That(_dataContext.Filters, Is.EqualTo(filters));
            Assert.That(_dataContext.Views, Is.EqualTo(views.ToDictionary(p => p.GetType())));
        }

        [Test]
        public void TestClearShouldClearDataProperties()
        {
            _dataContext.Sources.Add(typeof(CsvFileSource), new CsvFileSource());
            _dataContext.Columns.Add(new ColumnBuilder().Build());
            _dataContext.Rows.Add(new RowBuilder().Build());
            _dataContext.Filters.Add(new FakeFilter());
            _dataContext.Views.Add(typeof(ScatterPlot), new ScatterPlot());
            _dataContext.Clear();
            Assert.That(_dataContext.Sources.Count(), Is.EqualTo(0));
            Assert.That(_dataContext.Columns.Count(), Is.EqualTo(0));
            Assert.That(_dataContext.Rows.Count(), Is.EqualTo(0));
            Assert.That(_dataContext.Filters.Count(), Is.EqualTo(0));
            Assert.That(_dataContext.Views.Count(), Is.EqualTo(0));
        }
    }
}
