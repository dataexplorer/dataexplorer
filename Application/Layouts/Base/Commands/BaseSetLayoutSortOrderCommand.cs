using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Core.Commands;
using DataExplorer.Domain.Layouts;

namespace DataExplorer.Application.Layouts.Base.Commands
{
    public class BaseSetLayoutSortOrderCommand : ICommand
    {
        private readonly SortOrder _sortOrder;

        public BaseSetLayoutSortOrderCommand(SortOrder sortOrder)
        {
            _sortOrder = sortOrder;
        }

        public SortOrder SortOrder
        {
            get { return _sortOrder; }
        }
    }
}
