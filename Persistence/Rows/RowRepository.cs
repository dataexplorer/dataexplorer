using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using DataExplorer.Application;
using DataExplorer.Application.Rows;
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

        public Row Get(int id)
        {
            return _context.Rows
                .Single(p => p.Id == id);
        }

        public void Add(Row row)
        {
            _context.Rows.Add(row);
        }
    }
}
