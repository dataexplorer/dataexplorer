using System.Collections.Generic;
using DataExplorer.Domain.Sources.Maps;

namespace DataExplorer.Application.Importers.CsvFiles
{
    public interface ICsvFileImportService
    {
        CsvFileSourceDto GetSource();

        void UpdateSource(string filePath);

        List<SourceMap> GetMaps();

        bool CanImport();

        void Import();
    }
}
