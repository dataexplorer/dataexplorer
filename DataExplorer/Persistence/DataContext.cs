using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Projects;
using DataExplorer.Domain.Rows;
using DataExplorer.Domain.ScatterPlots;
using DataExplorer.Domain.Sources;
using DataExplorer.Domain.Views;

namespace DataExplorer.Persistence
{
    public class DataContext : IDataContext
    {
        private Dictionary<Type, ISource> _sources;
        private List<Column> _columns;
        private List<Row> _rows;
        private Dictionary<Type, IView> _views; 

        public Dictionary<Type, ISource> Sources
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

        public Dictionary<Type, IView> Views
        {
            get { return _views; }
        }

        public DataContext()
        {
            _sources = new Dictionary<Type, ISource>();
            _columns = new List<Column>();
            _rows = new List<Row>();
            _views = new Dictionary<Type, IView>();
        }

        public void SetProject(Project project)
        {
            _sources = project.Sources.ToDictionary(p => p.GetType());
            _columns = project.Columns;
            _rows = project.Rows;
            _views = project.DataViews.ToDictionary(p => p.GetType());
        }

        public void Clear()
        {
            _sources.Clear();
            _columns.Clear();
            _rows.Clear();
            _views.Clear();
        }
    }
}
