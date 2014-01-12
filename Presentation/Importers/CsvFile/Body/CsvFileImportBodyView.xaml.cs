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

namespace DataExplorer.Presentation.Importers.CsvFile.Body
{
    /// <summary>
    /// Interaction logic for CsvFileImportBodyView.xaml
    /// </summary>
    public partial class CsvFileImportBodyView : UserControl
    {
        public CsvFileImportBodyView()
        {
            InitializeComponent();
        }

        private void HandlePreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var cell = sender as DataGridCell;
            
            if (cell == null || cell.IsEditing || cell.IsReadOnly)
                return;
            
            if (!cell.IsFocused)
                cell.Focus();
            
            var dataGrid = FindVisualParent<DataGrid>(cell);
            
            if (dataGrid == null)
                return;
            
            if (dataGrid.SelectionUnit != DataGridSelectionUnit.FullRow)
            {
                if (!cell.IsSelected)
                    cell.IsSelected = true;
            }
            else
            {
                var row = FindVisualParent<DataGridRow>(cell);
                
                if (row != null && !row.IsSelected)
                    row.IsSelected = true;
            }
        }

        private static T FindVisualParent<T>(UIElement element) where T : UIElement
        {
            var parent = element;
            
            while (parent != null)
            {
                var typedParent = parent as T;
                
                if (typedParent != null)
                    return typedParent;
                
                parent = VisualTreeHelper.GetParent(parent) as UIElement;
            }

            return null;
        }
    }
}
