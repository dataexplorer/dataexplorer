using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.FilterTrees;
using DataExplorer.Domain.Filters;
using DataExplorer.Domain.Rows;

namespace DataExplorer.Application.Application
{
    public class ApplicationState
    {
        public bool IsStartMenuVisible { get; set; }

        public bool IsNavigationTreeVisible { get; set; }

        public Filter SelectedFilter { get; set; }

        public List<Row> SelectedRows { get; set; }
    }
}
