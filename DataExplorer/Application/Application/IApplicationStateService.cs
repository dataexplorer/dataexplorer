using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Filters;
using DataExplorer.Domain.Rows;

namespace DataExplorer.Application.Application
{
    public interface IApplicationStateService
    {
        bool IsStartMenuVisible { get; }

        bool IsNavigationTreeVisible { get; }
        
        Filter SelectedFilter { get; set; }
        
        List<Row> SelectedRows { get; set; }
    }
}
