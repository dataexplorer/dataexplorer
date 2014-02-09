using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace DataExplorer.Presentation.Panes.Legend.Colors
{
    public class ColorLegendItemViewModel : IColorLegendItem
    {
        private readonly Color _color;
        private readonly string _label;

        public Color Color
        {
            get { return _color; }
        }

        public string Label
        {
            get { return _label; }
        }

        public ColorLegendItemViewModel(Domain.Colors.Color color, string label)
        {
            _color = Color.FromRgb(color.Red, color.Green, color.Blue);
            _label = label;
        }
    }
}
