using System.Windows;

namespace DataExplorer.Presentation.Core
{
    public interface IDependencyPropertyService
    {
        void SetSource(DependencyObject source);
        void SetValue(DependencyProperty property, object value);
        object GetValue(DependencyProperty property);
    }
}
