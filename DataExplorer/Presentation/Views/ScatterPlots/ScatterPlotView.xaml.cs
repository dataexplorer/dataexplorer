using System.Windows.Controls;
using DataExplorer.Presentation.Core.Canvas.Events;

namespace DataExplorer.Presentation.Views.ScatterPlots
{
    /// <summary>
    /// Interaction logic for ScatterPlotView.xaml
    /// </summary>
    public partial class ScatterPlotView : UserControl
    {
        public ScatterPlotView()
        {
            InitializeComponent();
        }

        private void HandlePan(object sender, CanvasPanEventArgs e)
        {
            var viewModel = ((ScatterPlotViewModel) DataContext);
            viewModel.Pan(e.Delta);
        }
    }
}
