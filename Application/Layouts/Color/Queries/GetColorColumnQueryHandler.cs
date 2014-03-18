using System;
using System.Collections.Generic;
using System.Windows.Media.Imaging;
using DataExplorer.Application.Columns;
using DataExplorer.Application.Core.Queries;
using DataExplorer.Application.Views;

namespace DataExplorer.Application.Layouts.Color.Queries
{
    public class GetColorColumnQueryHandler
        : BaseGetLayoutColumnQueryHandler,
        IQueryHandler<GetColorColumnQuery, ColumnDto>
    {
        public GetColorColumnQueryHandler(
            IViewRepository repository,
            IColumnAdapter adapter)
            : base(repository, adapter)
        {
        }

        public ColumnDto Execute(GetColorColumnQuery query)
        {
            return base.Execute(p => p.ColorColumn);
        }
    }
}
