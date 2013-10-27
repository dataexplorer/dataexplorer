using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataExplorer.Presentation.Views.ScatterPlots.Scalers
{
    public class ValueScaler : IValueScaler
    {
        public double Scale(double value, double fromX, double fromWidth, double toX, double toWidth)
        {
            var scale = toWidth / fromWidth;

            return (value - fromX) * scale;
        }
    }
}
