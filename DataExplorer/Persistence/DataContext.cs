using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Projects;
using DataExplorer.Domain.Rows;
using DataExplorer.Domain.ScatterPlots;

namespace DataExplorer.Persistence
{
    public class DataContext : IDataContext
    {
        private List<Column> _columns;
        private List<Row> _rows;
        private IScatterPlot _scatterPlot;

        public List<Column> Columns
        {
            get { return _columns; }
        }

        public List<Row> Rows
        {
            get { return _rows; }
        }

        public IScatterPlot ScatterPlot
        {
            get { return _scatterPlot; }
            set { _scatterPlot = value; }
        }

        public DataContext()
        {
            _columns = new List<Column>();
            _rows = new List<Row>();
            _scatterPlot = new ScatterPlot();
        }

        public void SetProject(Project project)
        {
            _columns = project.Columns;
            _rows = project.Rows;
            _scatterPlot = project.ScatterPlot;
        }

        public void Clear()
        {
            _columns.Clear();
            _rows.Clear();
            _scatterPlot = new ScatterPlot();
        }
    }
}
