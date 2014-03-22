using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DataExplorer.Presentation.Core.DragDrop
{
    public class DragDropWrapper : IDragDropWrapper
    {
        public void DoDragDrop(DependencyObject dragSource, object dragData, DragDropEffects effects)
        {
            System.Windows.DragDrop.DoDragDrop(dragSource, dragData, DragDropEffects.Move);
        }
    }
}
