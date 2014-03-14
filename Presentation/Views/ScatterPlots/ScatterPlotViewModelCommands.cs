using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DataExplorer.Presentation.Core.Canvas.Items;
using DataExplorer.Presentation.Views.ScatterPlots.Commands;

namespace DataExplorer.Presentation.Views.ScatterPlots
{
    public class ScatterPlotViewModelCommands : IScatterPlotViewModelCommands
    {
        private readonly IResizeScatterPlotViewExtentCommand _resizeCommand;
        private readonly IZoomInScatterPlotCommand _zoomInCommand;
        private readonly IZoomOutScatterPlotCommand _zoomOutCommand;
        private readonly IPanScatterPlotCommand _panCommand;
        private readonly ISelectCommand _selectCommand;
        private readonly IExecuteCommand _executeCommand;

        public ScatterPlotViewModelCommands(
            IResizeScatterPlotViewExtentCommand resizeCommand,
            IZoomInScatterPlotCommand zoomInCommand,
            IZoomOutScatterPlotCommand zoomOutCommand,
            IPanScatterPlotCommand panCommand,
            ISelectCommand selectCommand,
            IExecuteCommand executeCommand)
        {
            _resizeCommand = resizeCommand;
            _zoomInCommand = zoomInCommand;
            _zoomOutCommand = zoomOutCommand;
            _panCommand = panCommand;
            _selectCommand = selectCommand;
            _executeCommand = executeCommand;
        }

        public void Resize(Size controlSize)
        {
            _resizeCommand.Execute(controlSize);
        }

        public void ZoomIn(Point center, Size size)
        {
            _zoomInCommand.Execute(center, size);
        }

        public void ZoomOut(Point center, Size size)
        {
            _zoomOutCommand.Execute(center, size);
        }

        public void Pan(Vector vector, Size size)
        {
            _panCommand.Execute(vector, size);
        }

        public void Select(List<CanvasItem> items)
        {
            _selectCommand.Execute(items);
        }

        public void Execute(int id)
        {
            _executeCommand.Execute(id);
        }
    }
}
