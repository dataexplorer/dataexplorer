using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Columns;

namespace DataExplorer.Application.Columns
{
    public class ColumnAdapter : IColumnAdapter
    {
        public ColumnDto Adapt(Column column)
        {
            if (column == null)
                return null;

            var columnDto = new ColumnDto()
            {
                Id = column.Id,
                Index = column.Index,
                Name = column.Name
            };

            return columnDto;
        }
    }
}
