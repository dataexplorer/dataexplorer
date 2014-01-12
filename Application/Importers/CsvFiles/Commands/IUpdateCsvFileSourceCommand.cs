namespace DataExplorer.Application.Importers.CsvFiles.Commands
{
    public interface IUpdateCsvFileSourceCommand
    {
        void Execute(string filePath);
    }
}