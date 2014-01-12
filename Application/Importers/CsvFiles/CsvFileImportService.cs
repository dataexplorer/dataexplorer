using System;
using System.Collections.Generic;
using System.Linq;
using DataExplorer.Application.Importers.CsvFiles.Commands;
using DataExplorer.Application.Importers.CsvFiles.Queries;
using DataExplorer.Domain.Sources.Maps;

namespace DataExplorer.Application.Importers.CsvFiles
{
    public class CsvFileImportService : ICsvFileImportService
    {
        private readonly IGetCsvFileSourceQuery _getSourceQuery;
        private readonly IUpdateCsvFileSourceCommand _updateCommand;
        private readonly IGetCsvFileSourceMapsQuery _getMapsQuery;
        private readonly ICanImportQuery _canImportQuery;
        private readonly IImportCsvFileSourceCommand _importCommand;

        public CsvFileImportService(
            IGetCsvFileSourceQuery getSourceQuery,
            IUpdateCsvFileSourceCommand updateCommand,
            IGetCsvFileSourceMapsQuery getMapsQuery,
            ICanImportQuery canImportQuery,
            IImportCsvFileSourceCommand importCommand)
        {
            _getSourceQuery = getSourceQuery;
            _updateCommand = updateCommand;
            _getMapsQuery = getMapsQuery;
            _canImportQuery = canImportQuery;
            _importCommand = importCommand;
        }

        public CsvFileSourceDto GetSource()
        {
            return _getSourceQuery.Query();
        }

        public void UpdateSource(string filePath)
        {
            _updateCommand.Execute(filePath);
        }
        
        public List<SourceMap> GetMaps()
        {
            return _getMapsQuery.Query();
        }

        public bool CanImport()
        {
            return _canImportQuery.Query();
        }

        public void Import()
        {
            _importCommand.Execute();
        }
    }
}
