using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Columns;

namespace DataExplorer.Persistence.Columns
{
    public class ColumnRepository : IColumnRepository
    {
        private readonly IColumnContext _context;

        public ColumnRepository(IColumnContext context)
        {
            _context = context;
        }

        public List<Column> GetAll()
        {
            return _context.Columns;
        }

        public void Add(Column column)
        {
            _context.Columns.Add(column);
        }
    }
}
