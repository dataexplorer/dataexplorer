using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Columns;

namespace DataExplorer.Application.Columns
{
    public interface IColumnAdapter
    {
        ColumnDto Adapt(Column column);
    }
}
