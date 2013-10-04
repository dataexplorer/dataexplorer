using DataExplorer.Domain.Sources;

namespace DataExplorer.Application.Importers.CsvFiles
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
