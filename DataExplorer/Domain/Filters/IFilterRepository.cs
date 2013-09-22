using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataExplorer.Domain.Filters
{
    public interface IFilterRepository
    {
        List<Filter> GetAll();
        void Add(Filter filter);
        void Remove(Filter filter);
    }
}
