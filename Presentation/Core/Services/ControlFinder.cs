using System.Windows;
using System.Windows.Media;

namespace DataExplorer.Presentation.Core.Services
{
    public class ControlFinder : IControlFinder
    {
        private readonly IVisualTreeHelper _helper;

        public ControlFinder(IVisualTreeHelper helper)
        {
            _helper = helper;
        }

        public T FindAncestor<T>(DependencyObject current) where T : DependencyObject
        {
            do
            {
                if (current is T)
                    return current as T;

                current = _helper.GetParent(current);
            }

            while (current != null);

            return null;
        }

        public T FindDecendant<T>(DependencyObject parent) where T : DependencyObject
        {
            if (parent == null)
                return null;

            if (parent is T)
                return (T) parent;

            var childrenCount = _helper.GetChildrenCount(parent);

            for (int i = 0; i < childrenCount; i++)
            {
                var child = _helper.GetChild(parent, i);
                
                var result = FindDecendant<T>(child);

                if (result != null)
                    return result;
            }

            return null;
        }
    }
}
