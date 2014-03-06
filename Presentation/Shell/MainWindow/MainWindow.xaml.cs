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
using DataExplorer.Application.Application;
using DataExplorer.Application.Application.Events;
using DataExplorer.Application.Core.Events;

namespace DataExplorer.Presentation.Shell.MainWindow
{
    public partial class MainWindow 
        : Window, 
        IMainWindow, 
        IEventHandler<PaneVisibilityChangedEvent>
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void Handle(PaneVisibilityChangedEvent args)
        {
            if (args.IsVisible == false)
                return;

            switch (args.Pane)
            {
                case Pane.Navigation:
                    NavigationPane.Show();
                    break;

                case Pane.Filter:
                    FilterPane.Show();
                    break;

                case Pane.Layout:
                    LayoutPane.Show();
                    break;

                case Pane.Legend:
                    LegendPane.Show();
                    break;

                case Pane.Property:
                    PropertyPane.Show();
                    break;
            }
        }
    }
}
