using System;
using System.Collections.Generic;
using DataExplorer.Domain.Rows;

namespace DataExplorer.Application.Rows
{
    public interface IRowRepository
    {
        IEnumerable<Row> GetAll();
        
        Row Get(int id);
        
        void Add(Row row);
    }
}
