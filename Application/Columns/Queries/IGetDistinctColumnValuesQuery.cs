using System.Collections.Generic;

namespace DataExplorer.Application.Columns.Queries
{
    public interface IGetDistinctColumnValuesQuery
    {
        IEnumerable<object> Execute(int id);
    }
}