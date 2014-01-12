using System.Windows;

namespace DataExplorer.Presentation.Core.Services
{
    public interface IControlFinder
    {
        T Find<T>(DependencyObject parent) where T : DependencyObject;
    }
}