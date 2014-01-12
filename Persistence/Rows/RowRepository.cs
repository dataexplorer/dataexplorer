using System;
using System.Collections.Generic;
using System.Data;
using DataExplorer.Application;
using DataExplorer.Domain.Rows;

namespace DataExplorer.Persistence.Rows
{
    public class RowRepository : IRowRepository
    {
        private readonly IDataContext _context;

        public RowRepository(IDataContext context)
        {
            _context = context;
        }

        public IEnumerable<Row> GetAll()
        {
            return _context.Rows;
        }

        public void Add(Row row)
        {
            _context.Rows.Add(row);
        }
    }
}
