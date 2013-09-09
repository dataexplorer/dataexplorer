using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Sources;

namespace DataExplorer.Application.Importers.CsvFile
{
    public class CsvFileSourceAdapter : ICsvFileSourceAdapter
    {
        public CsvFileSourceDto Adapt(CsvFileSource source)
        {
            var dto = new CsvFileSourceDto()
            {
                FilePath = source.FilePath
            };

            return dto;
        }
    }
}
