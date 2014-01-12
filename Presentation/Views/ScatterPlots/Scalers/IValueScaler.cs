using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataExplorer.Presentation.Views.ScatterPlots.Scalers
{
    public interface IValueScaler
    {
        double Scale(double value, double fromX, double fromWidth, double toX, double toWidth);
    }
}
