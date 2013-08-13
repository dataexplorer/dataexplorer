using System;
using System.Collections.Generic;
using System.Data;
using DataExplorer.Domain.Rows;

namespace DataExplorer.Persistence.Rows
{
    public class RowRepository : IRowRepository
    {
        private readonly IRowContext _context;

        public RowRepository(IRowContext context)
        {
            _context = context;
        }

        public List<Row> GetAll()
        {
            return _context.Rows;
        }

        public void Add(Row row)
        {
            _context.Rows.Add(row);
        }
    }
}
