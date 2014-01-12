using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application;
using DataExplorer.Domain.Columns;

namespace DataExplorer.Persistence.Columns
{
    public class ColumnRepository : IColumnRepository
    {
        private readonly IDataContext _context;

        public ColumnRepository(IDataContext context)
        {
            _context = context;
        }

        public List<Column> GetAll()
        {
            return _context.Columns;
        }

        public Column Get(int id)
        {
            return _context.Columns
                .Single(p => p.Id == id);
        }

        public void Add(Column column)
        {
            _context.Columns.Add(column);
        }
    }
}
