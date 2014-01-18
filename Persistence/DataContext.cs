using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Filters;
using DataExplorer.Domain.Projects;
using DataExplorer.Domain.Rows;
using DataExplorer.Domain.Sources;
using DataExplorer.Domain.Views;

namespace DataExplorer.Persistence
{
    public class DataContext : IDataContext
    {
        private Dictionary<Type, Source> _sources;
        private List<Column> _columns;
        private List<Row> _rows;
        private List<Filter> _filters; 
        private Dictionary<Type, View> _views; 

        public Dictionary<Type, Source> Sources
        {
            get { return _sources;  }
        }

        public List<Column> Columns
        {
            get { return _columns; }
        }

        public List<Row> Rows
        {
            get { return _rows; }
        }

        public List<Filter> Filters
        {
            get { return _filters; }
        }

        public Dictionary<Type, View> Views
        {
            get { return _views; }
        }

        public DataContext()
        {
            _sources = new Dictionary<Type, Source>();
            _columns = new List<Column>();
            _rows = new List<Row>();
            _filters = new List<Filter>();
            _views = new Dictionary<Type, View>();
        }

        public Project GetProject()
        {
            return new Project()
            {
                Sources = _sources.Values.ToList(),
                Columns = _columns.ToList(),
                Rows = _rows.ToList(),
                Filters = _filters.ToList(),
                Views = _views.Values.ToList()
            };
        }

        public void SetProject(Project project)
        {
            _sources = project.Sources.ToDictionary(p => p.GetType());
            _columns = project.Columns;
            _rows = project.Rows;
            _filters = project.Filters;
            _views = project.Views.ToDictionary(p => p.GetType());
        }

        public void Clear()
        {
            _sources.Clear();
            _columns.Clear();
            _rows.Clear();
            _filters.Clear();
            _views.Clear();
        }
    }
}
