using System.Windows.Input;

namespace DataExplorer.Presentation.Importers.CsvFile
{
    public interface ICsvFileImportHeaderViewModel
    {
        string FilePath { get; set; }
        
        ICommand BrowseCommand { get; }
    }
}