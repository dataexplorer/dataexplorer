using System.Windows;
using System.Windows.Controls;
using DataExplorer.Domain.Filters;
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

        private void HandleExecute(object sender, CanvasExecuteEventArgs e)
        {
            var viewModel = ((ScatterPlotViewModel) DataContext);
            viewModel.HandleExecute(e.Id);
        }

        private void HandleDragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(Filter)))
            {
                var filter = (Filter) e.Data.GetData(typeof(Filter));
                
                var viewModel = ((ScatterPlotViewModel) DataContext);

                if (viewModel.IsValidLayoutDropSource(filter.Column))
                    return;
            }

            e.Effects = DragDropEffects.None;
            e.Handled = true;
        }

        private void HandleDrop(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(typeof (Filter)))
                return;

            var filter = (Filter) e.Data.GetData(typeof(Filter));

            var viewModel = ((ScatterPlotViewModel)DataContext);
            
            viewModel.HandleSetDragDropLayout(filter.Column);
        }
    }
}
