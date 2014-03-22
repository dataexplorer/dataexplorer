using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using DataExplorer.Domain.Filters;
using DataExplorer.Presentation.Core.DragDrop;
using DataExplorer.Presentation.Panes.Navigation.NavigationTree;

namespace DataExplorer.Presentation.Core.Services
{
    // TODO: This class should probably be unit tested someday
    // TODO: Will need to create a wrapper for treeview to pull it off

    public class NavigationTreeDragDropHelper
    {
        private readonly ControlFinder _controlFinder;
        private readonly DragDropWrapper _dragDropWrapper;
        private Point _startPosition;

        public NavigationTreeDragDropHelper()
        {
            _controlFinder = new ControlFinder(
                new VisualTreeHelperWrapper());
            _dragDropWrapper = new DragDropWrapper();
        }

        public void HandlePreviewMouseLeftButtonDown(Point position)
        {
            _startPosition = position;
        }

        public void HandlePreviewMouseMove(TreeView treeView, object originalSource, Point position, MouseButtonState leftButtonState)
        {
            var delta = _startPosition - position;

            if (!IsMouseDragEvent(leftButtonState, delta)) 
                return;

            var treeViewItem = _controlFinder
                .FindAncestor<TreeViewItem>((DependencyObject) originalSource);
            
            if (treeViewItem == null)
                return;

            var treeNode = (TreeNodeViewModel) treeView.SelectedItem;

            if (treeNode == null)
                return;

            var filter = treeNode.Filter;

            var dragData = new DataObject(typeof(Filter), filter);
            
            _dragDropWrapper.DoDragDrop(treeViewItem, dragData, DragDropEffects.Move);
        }

        private static bool IsMouseDragEvent(MouseButtonState leftButtonState, Vector delta)
        {
            return leftButtonState == MouseButtonState.Pressed
                   && (Math.Abs(delta.X) > SystemParameters.MinimumHorizontalDragDistance
                       || Math.Abs(delta.Y) > SystemParameters.MinimumVerticalDragDistance);
        }
    }
}
