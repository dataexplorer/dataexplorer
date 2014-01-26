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
        bool GetIsStartMenuVisible();

        bool GetIsNavigationTreeVisible();

        Filter GetSelectedFilter();

        void SetSelectedFilter(Filter filter);

        void ClearSelectedFilter();

        List<Row> GetSelectedRows();

        void SetSelectedRows(List<Row> rows);

        void ClearSelectedRows();
    }
}
