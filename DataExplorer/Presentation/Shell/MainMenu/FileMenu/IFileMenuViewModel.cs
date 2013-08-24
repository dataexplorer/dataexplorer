using System.Windows.Input;

namespace DataExplorer.Presentation.Shell.MainMenu.FileMenu
{
    public interface IFileMenuViewModel
    {
        ICommand OpenCommand { get; }
        ICommand CloseCommand { get; }
        ICommand ImportCommand { get; }
        ICommand ExitCommand { get; }
    }
}