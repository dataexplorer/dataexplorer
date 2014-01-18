using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application;
using DataExplorer.Application.Filters;
using DataExplorer.Domain.Filters;

namespace DataExplorer.Persistence.Filters
{
    public class FilterRepository : IFilterRepository
    {
        private readonly IDataContext _context;

        public FilterRepository(IDataContext context)
        {
            _context = context;
        }

        public List<Filter> GetAll()
        {
            return _context.Filters;
        }

        public void Add(Filter filter)
        {
            _context.Filters.Add(filter);
        }

        public void Remove(Filter filter)
        {
            _context.Filters.Remove(filter);
        }
    }
}
