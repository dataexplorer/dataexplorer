using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DataExplorer.Presentation.Core.DragDrop
{
    public interface IDragDropWrapper
    {
        void DoDragDrop(DependencyObject dragSource, object dragData, DragDropEffects effects);
    }
}
