using System.Collections.Generic;
using DataExplorer.Domain.Sources.Maps;

namespace DataExplorer.Application.Importers.CsvFiles.Queries
{
    public interface IGetCsvFileSourceMapsQuery
    {
        List<SourceMap> Query();
    }
}