using System.Collections.Generic;

namespace DataExplorer.Domain.Columns
{
    public interface IColumnRepository
    {
        List<Column> GetAll();
        Column Get(int id);
        void Add(Column column);
    }
}
