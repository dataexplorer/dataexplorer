using System;
using DataExplorer.Application.Layouts.Base.Commands;
using DataExplorer.Domain.Layouts;

namespace DataExplorer.Application.Layouts.Color.Commands
{
    public class SetColorSortOrderCommand : BaseSetLayoutSortOrderCommand
    {
        public SetColorSortOrderCommand(SortOrder sortOrder) : base(sortOrder)
        {
        }
    }
}
