using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Events;

namespace DataExplorer.Domain.ScatterPlots
{
    public class ScatterPlotLayout
    {
        private Column _xAxisColumn;

        public Column XAxisColumn
        {
            get { return _xAxisColumn; }
            set
            {
                _xAxisColumn = value;
                DomainEvents.Raise(new ScatterPlotLayoutChangedEvent());
            }
        }
    }
}
