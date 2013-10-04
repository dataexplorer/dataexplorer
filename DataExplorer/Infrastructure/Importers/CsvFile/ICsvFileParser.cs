namespace DataExplorer.Infrastructure.Importers.CsvFile
{
    public interface ICsvFileParser
    {
        void OpenFile(string filePath);
        string[] ReadFields();
        bool IsEndOfFile();
        void CloseFile();
    }
}
