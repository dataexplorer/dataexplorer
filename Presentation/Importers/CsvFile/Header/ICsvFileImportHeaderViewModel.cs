using System.Windows.Input;

namespace DataExplorer.Presentation.Importers.CsvFile.Header
{
    public interface ICsvFileImportHeaderViewModel
    {
        string FilePath { get; }
        
        ICommand BrowseCommand { get; }
    }
}