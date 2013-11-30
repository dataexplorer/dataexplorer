using System.Collections.Generic;
using DataExplorer.Domain.Filters;
using DataExplorer.Domain.Rows;

namespace DataExplorer.Application.Application
{
    public interface IApplicationState
    {
        bool IsStartMenuVisible { get; set; }
        bool IsNavigationTreeVisible { get; set; }
        Filter SelectedFilter { get; set; }
        List<Row> SelectedRows { get; set; }
    }
}