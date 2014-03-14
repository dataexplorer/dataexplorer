using System;
using DataExplorer.Presentation.Panes.Layout.Color;
using DataExplorer.Presentation.Panes.Layout.Label;
using DataExplorer.Presentation.Panes.Layout.Link;
using DataExplorer.Presentation.Panes.Layout.Location;
using DataExplorer.Presentation.Panes.Layout.Shape;
using DataExplorer.Presentation.Panes.Layout.Size;

namespace DataExplorer.Presentation.Panes.Layout
{
    public class LayoutPaneViewModel : ILayoutPaneViewModel
    {
        private readonly IXAxisLayoutViewModel _xAxisLayoutViewModel;
        private readonly IYAxisLayoutViewModel _yAxisLayoutViewModel;
        private readonly IColorLayoutViewModel _colorLayoutViewModel;
        private readonly ISizeLayoutViewModel _sizeLayoutViewModel;
        private readonly IShapeLayoutViewModel _shapeLayoutViewModel;
        private readonly ILabelLayoutViewModel _labelLayoutViewModel;
        private readonly ILinkLayoutViewModel _linkLayoutViewModel;

        public LayoutPaneViewModel(
            IXAxisLayoutViewModel xAxisLayoutViewModel, 
            IYAxisLayoutViewModel yAxisLayoutViewModel, 
            IColorLayoutViewModel colorLayoutViewModel,
            ISizeLayoutViewModel sizeLayoutViewModel,
            IShapeLayoutViewModel shapeLayoutViewModel,
            ILabelLayoutViewModel labelLayoutViewModel,
            ILinkLayoutViewModel linkLayoutViewModel)
        {
            _xAxisLayoutViewModel = xAxisLayoutViewModel;
            _yAxisLayoutViewModel = yAxisLayoutViewModel;
            _colorLayoutViewModel = colorLayoutViewModel;
            _sizeLayoutViewModel = sizeLayoutViewModel;
            _labelLayoutViewModel = labelLayoutViewModel;
            _linkLayoutViewModel = linkLayoutViewModel;
            _shapeLayoutViewModel = shapeLayoutViewModel;
        }

        public IXAxisLayoutViewModel XAxisLayoutViewModel
        {
            get { return _xAxisLayoutViewModel; }
        }

        public IYAxisLayoutViewModel YAxisLayoutViewModel
        {
            get { return _yAxisLayoutViewModel; }
        }

        public IColorLayoutViewModel ColorLayoutViewModel
        {
            get { return _colorLayoutViewModel; }
        }

        public ISizeLayoutViewModel SizeLayoutViewModel
        {
            get { return _sizeLayoutViewModel; }
        }

        public IShapeLayoutViewModel ShapeLayoutViewModel
        {
            get { return _shapeLayoutViewModel; }
        }
        
        public ILabelLayoutViewModel LabelLayoutViewModel
        {
            get { return _labelLayoutViewModel; }
        }

        public ILinkLayoutViewModel LinkLayoutViewModel
        {
            get { return _linkLayoutViewModel; }
        }
    }
}
