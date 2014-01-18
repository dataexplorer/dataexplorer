using System.Collections.Generic;
using DataExplorer.Domain.Columns;

namespace DataExplorer.Application.Columns
{
    public interface IColumnRepository
    {
        List<Column> GetAll();
        Column Get(int id);
        void Add(Column column);
    }
}
