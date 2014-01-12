using DataExplorer.Domain.Sources;

namespace DataExplorer.Application.Importers.CsvFiles
{
    public interface ICsvFileSourceAdapter
    {
        CsvFileSourceDto Adapt(CsvFileSource source);
    }
}
