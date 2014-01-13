using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Core.Queries;
using DataExplorer.Domain.Sources.Maps;

namespace DataExplorer.Application.Importers.CsvFiles.Queries
{
    public class GetCsvFileSourceMapsQuery : IQuery<List<SourceMap>>
    {
    }
}
