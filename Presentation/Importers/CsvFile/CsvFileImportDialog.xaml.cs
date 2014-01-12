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
using System.Windows.Shapes;
using DataExplorer.Presentation.Dialogs;

namespace DataExplorer.Presentation.Importers.CsvFile
{
    /// <summary>
    /// Interaction logic for ImportCsvFileDialog.xaml
    /// </summary>
    public partial class ImportCsvFileDialog : Window, IDialog
    {
        public ImportCsvFileDialog()
        {
            InitializeComponent();

            DataContextChanged += HandleDataContextChanged;
        }

        private void HandleDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (e.OldValue is ICsvFileImportViewModel)
                ((ICsvFileImportViewModel)e.NewValue).FooterViewModel.DialogClosed -= HandleDialogClosed;

            if (e.NewValue is ICsvFileImportViewModel)
                ((ICsvFileImportViewModel) e.NewValue).FooterViewModel.DialogClosed += HandleDialogClosed;
            
        }

        private void HandleDialogClosed(object sender, EventArgs eventArgs)
        {
            if (System.Windows.Threading.Dispatcher.CurrentDispatcher.Thread.IsBackground)
            {
                base.Dispatcher.Invoke(() => HandleDialogClosed(sender, eventArgs));
                return;
            }

            this.Close();
        }
    }
}
