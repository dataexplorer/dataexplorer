using System.Windows;

namespace DataExplorer.Presentation.Core.Services
{
    public interface IControlFinder
    {
        T FindAncestor<T>(DependencyObject current) where T : DependencyObject;
        
        T FindDecendant<T>(DependencyObject parent) where T : DependencyObject;
    }
}