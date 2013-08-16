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
    public interface IDataContext
    {
        List<Column> Columns { get; }
        
        List<Row> Rows { get; }

        IScatterPlot ScatterPlot { get; set; }

        void SetProject(Project project);
        
        void Clear();
    }
}
