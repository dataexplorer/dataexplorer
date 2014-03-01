using System;

namespace DataExplorer.Presentation.Panes.Legend.Sizes
{
    public class SizeLegendItemViewModel : ISizeLegendItem
    {
        private readonly double _size;
        private readonly string _label;

        public double Size
        {
            get { return _size; }
        }

        public string Label
        {
            get { return _label; }
        }

        public SizeLegendItemViewModel(double size, string label)
        {
            _size = size;
            _label = label;
        }
    }
}
