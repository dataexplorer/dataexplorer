using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Presentation.Core.Canvas.Items;

namespace DataExplorer.Presentation.Views.ScatterPlots.Commands
{
    public interface ISelectCommand
    {
        void Execute(List<CanvasItem> items);
    }
}
