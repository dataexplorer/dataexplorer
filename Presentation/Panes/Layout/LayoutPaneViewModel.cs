using System;
using DataExplorer.Presentation.Panes.Layout.Color;
using DataExplorer.Presentation.Panes.Layout.Location;
using DataExplorer.Presentation.Panes.Layout.Size;

namespace DataExplorer.Presentation.Panes.Layout
{
    public class LayoutPaneViewModel : ILayoutPaneViewModel
    {
        private readonly IXAxisLayoutViewModel _xAxisLayoutViewModel;
        private readonly IYAxisLayoutViewModel _yAxisLayoutViewModel;
        private readonly IColorLayoutViewModel _colorLayoutViewModel;
        private readonly ISizeLayoutViewModel _sizeLayoutViewModel;

        public LayoutPaneViewModel(
            IXAxisLayoutViewModel xAxisLayoutViewModel, 
            IYAxisLayoutViewModel yAxisLayoutViewModel, 
            IColorLayoutViewModel colorLayoutViewModel,
            ISizeLayoutViewModel sizeLayoutViewModel)
        {
            _xAxisLayoutViewModel = xAxisLayoutViewModel;
            _yAxisLayoutViewModel = yAxisLayoutViewModel;
            _colorLayoutViewModel = colorLayoutViewModel;
            _sizeLayoutViewModel = sizeLayoutViewModel;
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
    }
}
