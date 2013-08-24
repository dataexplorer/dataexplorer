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
    public interface IDataContext
    {
        Dictionary<Type, ISource> Sources { get; }
        
        List<Column> Columns { get; }

        List<Row> Rows { get; }

        Dictionary<Type, IView> Views { get; }

        void SetProject(Project project);
        
        void Clear();
    }
}
