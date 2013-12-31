using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Filters;
using DataExplorer.Domain.Projects;
using DataExplorer.Domain.Rows;
using DataExplorer.Domain.Sources;
using DataExplorer.Domain.Views;
using DataExplorer.Persistence;
using DataExplorer.Tests.Domain.Columns;
using DataExplorer.Tests.Domain.Filters;
using DataExplorer.Tests.Domain.Rows;
using DataExplorer.Tests.Domain.Sources;
using DataExplorer.Tests.Domain.Views;
using NUnit.Framework;

namespace DataExplorer.Tests.Persistence
{
    [TestFixture]
    public class DataContextTests
    {
        private DataContext _dataContext;
        private Project _project;
        private FakeSource _source;
        private Column _column;
        private Row _row;
        private Filter _filter;
        private FakeView _view;

        [SetUp]
        public void SetUp()
        {
            _source = new FakeSource();
            _column = new ColumnBuilder().Build();
            _row = new RowBuilder().Build();
            _filter = new FakeFilter();
            _view = new FakeView();
            
            _project = new Project()
            {
                Sources = new List<ISource> { _source },
                Columns = new List<Column> { _column },
                Rows = new List<Row> { _row },
                Filters = new List<Filter> { _filter },
                Views = new List<IView> { _view }
            };

            _dataContext = new DataContext();

            _dataContext.Sources.Add(_source.GetType(), _source);
            _dataContext.Columns.Add(_column);
            _dataContext.Rows.Add(_row);
            _dataContext.Filters.Add(_filter);
            _dataContext.Views.Add(_view.GetType(), _view);
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
        public void TestGetProjectShouldGetProjectFromDataContext()
        {
            var result = _dataContext.GetProject();
            Assert.That(result.Sources.Single(), Is.EqualTo(_source));
            Assert.That(result.Columns.Single(), Is.EqualTo(_column));
            Assert.That(result.Rows.Single(), Is.EqualTo(_row));
            Assert.That(result.Filters.Single(), Is.EqualTo(_filter));
            Assert.That(result.Views.Single(), Is.EqualTo(_view));
        }

        [Test]
        public void TestSetProjectShouldSetDataContextToProject()
        {
           _dataContext.SetProject(_project);
            Assert.That(_dataContext.Sources.Single().Value, Is.EqualTo(_source));
            Assert.That(_dataContext.Columns.Single(), Is.EqualTo(_column));
            Assert.That(_dataContext.Rows.Single(), Is.EqualTo(_row));
            Assert.That(_dataContext.Filters.Single(), Is.EqualTo(_filter));
            Assert.That(_dataContext.Views.Single().Value, Is.EqualTo(_view));
        }

        [Test]
        public void TestClearShouldClearDataProperties()
        {
            _dataContext.Clear();
            Assert.That(_dataContext.Sources.Count(), Is.EqualTo(0));
            Assert.That(_dataContext.Columns.Count(), Is.EqualTo(0));
            Assert.That(_dataContext.Rows.Count(), Is.EqualTo(0));
            Assert.That(_dataContext.Filters.Count(), Is.EqualTo(0));
            Assert.That(_dataContext.Views.Count(), Is.EqualTo(0));
        }
    }
}
