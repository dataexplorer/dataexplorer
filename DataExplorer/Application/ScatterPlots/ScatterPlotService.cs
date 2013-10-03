using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DataExplorer.Application.ScatterPlots.Commands;
using DataExplorer.Application.ScatterPlots.Queries;
using DataExplorer.Domain.ScatterPlots;
using DataExplorer.Domain.Views;

namespace DataExplorer.Application.ScatterPlots
{
    public class ScatterPlotService : IScatterPlotService
    {
        private readonly IGetViewExtentQuery _getViewExtentQuery;
        private readonly ISetViewExtentCommand _setViewExtentCommand;
        private readonly IGetPlotsQuery _getPlotsQuery;
        private readonly IZoomInCommand _zoomInCommand;
        private readonly IZoomOutCommand _zoomOutCommand;
        private readonly IZoomToFullExtentCommand _zoomToFullExtentCommand;
        private readonly IPanCommand _panCommand;

        public ScatterPlotService(
            IGetViewExtentQuery getViewExtentQuery,
            ISetViewExtentCommand setViewExtentCommand,
            IGetPlotsQuery getPlotsQuery, 
            IZoomInCommand zoomInCommand,
            IZoomOutCommand zoomOutCommand,
            IZoomToFullExtentCommand zoomToFullExtentCommand,
            IPanCommand panCommand)
        {
            _getViewExtentQuery = getViewExtentQuery;
            _setViewExtentCommand = setViewExtentCommand;
            _getPlotsQuery = getPlotsQuery;
            _zoomInCommand = zoomInCommand;
            _zoomOutCommand = zoomOutCommand;
            _zoomToFullExtentCommand = zoomToFullExtentCommand;
            _panCommand = panCommand;
        }

        public Rect GetViewExtent()
        {
            return _getViewExtentQuery.GetViewExtent();
        }

        public void SetViewExtent(Rect viewExtent)
        {
            _setViewExtentCommand.SetViewExtent(viewExtent);
        }

        public List<PlotDto> GetPlots()
        {
            return _getPlotsQuery.GetPlots();
        }

        public void ZoomIn(Point center)
        {
            _zoomInCommand.ZoomIn(center);
        }

        public void ZoomOut(Point center)
        {
            _zoomOutCommand.ZoomOut(center);
        }

        public void ZoomToFullExtent()
        {
            _zoomToFullExtentCommand.Execute();
        }

        public void Pan(Vector vector)
        {
            _panCommand.Pan(vector);
        }
    }
}
