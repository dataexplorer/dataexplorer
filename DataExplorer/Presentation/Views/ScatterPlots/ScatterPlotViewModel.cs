using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using DataExplorer.Application.ScatterPlots;
using DataExplorer.Domain.Events;
using DataExplorer.Domain.ScatterPlots;
using DataExplorer.Presentation.Core;
using DataExplorer.Presentation.Core.Canvas.Items;
using DataExplorer.Presentation.Views.ScatterPlots.Commands;
using DataExplorer.Presentation.Views.ScatterPlots.Queries;
using DataExplorer.Presentation.Views.ScatterPlots.Scalers;

namespace DataExplorer.Presentation.Views.ScatterPlots
{
    public class ScatterPlotViewModel 
        : BaseViewModel, 
        IScatterPlotViewModel,
        IDomainHandler<ScatterPlotChangedEvent>
    {
        private readonly IScatterPlotContextMenuViewModel _contextMenuViewModel;
        private readonly IGetScatterPlotItemsQuery _getItemsQuery;
        private readonly IResizeScatterPlotViewExtentCommand _resizeCommand;
        private readonly IZoomInScatterPlotCommand _zoomInCommand;
        private readonly IZoomOutScatterPlotCommand _zoomOutCommand;
        private readonly IPanScatterPlotCommand _panCommand;
        private Size _controlSize;

        public IScatterPlotContextMenuViewModel ContextMenuViewModel
        {
            get { return _contextMenuViewModel; }
        }

        public Size ControlSize
        {
            set { HandleControlSizeChanged(value); }
        }

        public List<ICanvasItem> Items
        {
            get { return GetItems().ToList(); }
        }
        
        public ScatterPlotViewModel(
            IScatterPlotContextMenuViewModel contextMenuViewModel,
            IGetScatterPlotItemsQuery getItemsQuery,
            IResizeScatterPlotViewExtentCommand resizeCommand,
            IZoomInScatterPlotCommand zoomInCommand,
            IZoomOutScatterPlotCommand zoomOutCommand,
            IPanScatterPlotCommand panCommand)
        {
            _contextMenuViewModel = contextMenuViewModel;
            _getItemsQuery = getItemsQuery;
            _resizeCommand = resizeCommand;
            _zoomInCommand = zoomInCommand;
            _zoomOutCommand = zoomOutCommand;
            _panCommand = panCommand;
        }

        private IEnumerable<ICanvasItem> GetItems()
        {
            return _getItemsQuery.Execute(_controlSize);
        }

        private void HandleControlSizeChanged(Size controlSize)
        {
            _controlSize = controlSize;

            _resizeCommand.Execute(_controlSize);
        }

        public void HandleZoomIn(Point center)
        {
            _zoomInCommand.Execute(center, _controlSize);
        }

        public void HandleZoomOut(Point center)
        {
            _zoomOutCommand.Execute(center, _controlSize);
        }

        public void HandlePan(Vector vector)
        {
            _panCommand.Execute(vector, _controlSize);
        }

        public void Handle(ScatterPlotChangedEvent args)
        {
            OnPropertyChanged(() => Items);
        }
    }
}
