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
        
        public T Find<T>(DependencyObject parent) where T : DependencyObject
        {
            if (parent == null)
                return null;

            if (parent is T)
                return (T) parent;

            var childrenCount = _helper.GetChildrenCount(parent);

            for (int i = 0; i < childrenCount; i++)
            {
                var child = _helper.GetChild(parent, i);
                
                var result = Find<T>(child);

                if (result != null)
                    return result;
            }

            return null;
        }
    }
}
