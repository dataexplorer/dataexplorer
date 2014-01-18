using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Filters;
using DataExplorer.Domain.Rows;
using DataExplorer.Domain.Sources;
using DataExplorer.Domain.Views;

namespace DataExplorer.Domain.Projects
{
    public class Project
    {
        public List<Source> Sources { get; set; }

        public List<Column> Columns { get; set; }

        public List<Row> Rows { get; set; }

        public List<Filter> Filters { get; set; } 

        public List<View> Views  { get; set; }
    }
}
