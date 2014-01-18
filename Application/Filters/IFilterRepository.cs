using System;
using System.Collections.Generic;
using DataExplorer.Domain.Filters;

namespace DataExplorer.Application.Filters
{
    public interface IFilterRepository
    {
        List<Filter> GetAll();
        void Add(Filter filter);
        void Remove(Filter filter);
    }
}
