using System.Collections.Generic;
using System.Data;
using DataExplorer.Domain.Sources;

namespace DataExplorer.Application.Importers.CsvFiles
{
    public interface ICsvFileDataAdapter
    {
        bool Exists(CsvFileSource source);

        List<SourceColumn> GetColumns(CsvFileSource source);

        DataTable GetTable(CsvFileSource source);
    }
}
