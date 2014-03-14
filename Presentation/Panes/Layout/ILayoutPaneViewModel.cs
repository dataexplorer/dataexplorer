using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Presentation.Panes.Layout.Color;
using DataExplorer.Presentation.Panes.Layout.Label;
using DataExplorer.Presentation.Panes.Layout.Link;
using DataExplorer.Presentation.Panes.Layout.Location;
using DataExplorer.Presentation.Panes.Layout.Shape;
using DataExplorer.Presentation.Panes.Layout.Size;

namespace DataExplorer.Presentation.Panes.Layout
{
    public interface ILayoutPaneViewModel
    {
        IXAxisLayoutViewModel XAxisLayoutViewModel { get; }
       
        IYAxisLayoutViewModel YAxisLayoutViewModel { get; }
        
        IColorLayoutViewModel ColorLayoutViewModel { get; }
        
        ISizeLayoutViewModel SizeLayoutViewModel { get; }

        IShapeLayoutViewModel ShapeLayoutViewModel { get; }

        ILabelLayoutViewModel LabelLayoutViewModel { get; }

        ILinkLayoutViewModel LinkLayoutViewModel { get; }
        
    }
}
