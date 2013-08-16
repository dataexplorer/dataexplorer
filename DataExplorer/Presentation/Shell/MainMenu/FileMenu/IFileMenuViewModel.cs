using System.Windows.Input;

namespace DataExplorer.Presentation.Shell.MainMenu.FileMenu
{
    public interface IFileMenuViewModel
    {
        ICommand OpenCommand { get; }
        ICommand CloseCommand { get; }
        ICommand ExitCommand { get; }
    }
}