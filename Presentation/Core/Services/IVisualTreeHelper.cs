using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DataExplorer.Presentation.Core.Services
{
    public interface IVisualTreeHelper
    {
        int GetChildrenCount(DependencyObject reference);

        DependencyObject GetParent(DependencyObject reference);

        DependencyObject GetChild(DependencyObject reference, int childIndex);
    }
}
