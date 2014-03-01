using System;

namespace DataExplorer.Presentation.Panes.Legend.Sizes
{
    public interface ISizeLegendItem
    {
        double Size { get; }

        string Label { get; }
    }
}
