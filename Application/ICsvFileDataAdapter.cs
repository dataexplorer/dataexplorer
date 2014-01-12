using System.Collections.Generic;
using System.Data;
using DataExplorer.Domain.Sources;

namespace DataExplorer.Infrastructure.Importers.CsvFile
{
    public interface ICsvFileDataAdapter
    {
        bool Exists(CsvFileSource source);
        DataTable GetDataTable(CsvFileSource source);
        List<DataColumn> GetDataColumns(CsvFileSource source);
    }
}
