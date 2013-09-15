using System.Windows.Input;
using DataExplorer.Presentation.Core.Events;

namespace DataExplorer.Presentation.Importers.CsvFile.Footer
{
    public interface ICsvFileImportFooterViewModel
    {
        event DialogClosedEvent DialogClosed;

        ICommand ImportCommand { get; }

        ICommand CancelCommand { get; }

        bool IsProgressBarVisible { get; }

        double Progress { get; }
    }
}