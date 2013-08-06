using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.ScatterPlot;

namespace DataExplorer.Persistence.View
{
    public interface IViewContext
    {
        IScatterPlot ScatterPlot { get; set; }
    }
}
