using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Sources;
using DataExplorer.Domain.Sources.Maps;

namespace DataExplorer.Application.Importers.CsvFiles.Queries
{
    public class GetCsvFileSourceMapsQuery : IGetCsvFileSourceMapsQuery
    {
        private readonly ISourceRepository _repository;

        public GetCsvFileSourceMapsQuery(ISourceRepository repository)
        {
            _repository = repository;
        }

        public List<SourceMap> Query()
        {
            var source = _repository.GetSource<CsvFileSource>();

            var maps = source.GetMaps();

            return maps.ToList();
        }
    }
}
