using System.Windows.Input;

namespace DataExplorer.Presentation.Shell.MainMenu.FileMenu
{
    public interface IFileMenuViewModel
    {
        ICommand ExitCommand { get; }
        ICommand OpenCommand { get; }
    }
}