using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.ScatterPlots;

namespace DataExplorer.Domain.Views
{
    public interface IViewRepository
    {
        IScatterPlot GetScatterPlot();
        void Add(IScatterPlot view);
    }
}
