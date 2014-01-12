using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace DataExplorer.Presentation.Core.Services
{
    public class VisualTreeHelperWrapper : IVisualTreeHelper
    {
        public int GetChildrenCount(DependencyObject reference)
        {
            return VisualTreeHelper.GetChildrenCount(reference);
        }

        public DependencyObject GetChild(DependencyObject reference, int childIndex)
        {
            return VisualTreeHelper.GetChild(reference, childIndex);
        }
    }
}
