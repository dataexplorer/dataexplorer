using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DataExplorer.Presentation.Core.Services;

namespace DataExplorer.Presentation.Panes.Navigation.NavigationTree
{
    /// <summary>
    /// Interaction logic for NavigationTreeView.xaml
    /// </summary>
    public partial class NavigationTreeView : UserControl
    {
        private readonly NavigationTreeDragDropHelper _navigationTreeDragDropHelper;

        public NavigationTreeView()
        {
            _navigationTreeDragDropHelper = new NavigationTreeDragDropHelper();

            InitializeComponent();
        }

        private void HandlePreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _navigationTreeDragDropHelper.HandlePreviewMouseLeftButtonDown(e.GetPosition(null));
        }

        private void HandlePreviewMouseMove(object sender, MouseEventArgs e)
        {
            _navigationTreeDragDropHelper.HandlePreviewMouseMove(
                TreeView,
                e.OriginalSource,
                e.GetPosition(null),
                e.LeftButton);
        }
    }
}
