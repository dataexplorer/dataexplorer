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

        private void HandleZoomIn(object sender, CanvasZoomInEventArg e)
        {
            var viewModel = ((ScatterPlotViewModel) DataContext);
            viewModel.HandleZoomIn(e.Center);
        }

        private void HandleZoomOut(object sender, CanvasZoomOutEventArgs e)
        {
            var viewModel = ((ScatterPlotViewModel) DataContext);
            viewModel.HandleZoomOut(e.Point);
        }

        private void HandlePan(object sender, CanvasPanEventArgs e)
        {
            var viewModel = ((ScatterPlotViewModel) DataContext);
            viewModel.HandlePan(e.Delta);
        }
    }
}
