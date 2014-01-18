using System;
using System.Collections.Generic;
using DataExplorer.Domain.Rows;

namespace DataExplorer.Application.Rows
{
    public interface IRowRepository
    {
        IEnumerable<Row> GetAll();
        void Add(Row row);
    }
}
