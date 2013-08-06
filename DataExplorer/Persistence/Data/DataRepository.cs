using System;
using System.Collections.Generic;
using System.Data;
using DataExplorer.Domain.Data;

namespace DataExplorer.Persistence.Data
{
    public class DataRepository : IDataRepository
    {
        private readonly IDataContext _context;

        public DataRepository(IDataContext context)
        {
            _context = context;
        }

        public List<DataRow> GetAll()
        {
            return _context.DataRows;
        }
    }
}
