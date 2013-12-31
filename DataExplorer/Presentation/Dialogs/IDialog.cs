using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DataExplorer.Presentation.Dialogs
{
    public interface IDialog
    {
        object DataContext { get; set; }

        Window Owner { get; set; }
        
        WindowStartupLocation WindowStartupLocation { get; set; }
        
        bool? ShowDialog();
    }
}
