using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Sources.Maps;

namespace DataExplorer.Application.Importers.CsvFile
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
