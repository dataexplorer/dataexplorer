using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Core.Queries;
using DataExplorer.Domain.Sources;
using DataExplorer.Domain.Sources.Maps;

namespace DataExplorer.Application.Importers.CsvFiles.Queries
{
    public class GetCsvFileSourceMapsQueryHandler 
        : IQueryHandler<GetCsvFileSourceMapsQuery, List<SourceMap>>
    {
        private readonly ISourceRepository _repository;

        public GetCsvFileSourceMapsQueryHandler(ISourceRepository repository)
        {
            _repository = repository;
        }

        public List<SourceMap> Execute(GetCsvFileSourceMapsQuery query)
        {
            var source = _repository.GetSource<CsvFileSource>();

            var maps = source.GetMaps();

            return maps.ToList();
        }
    }
}
