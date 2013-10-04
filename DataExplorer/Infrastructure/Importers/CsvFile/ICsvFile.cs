namespace DataExplorer.Infrastructure.Importers.CsvFile
{
    public interface ICsvFile
    {
        bool Exists(string filePath);
    }
}
