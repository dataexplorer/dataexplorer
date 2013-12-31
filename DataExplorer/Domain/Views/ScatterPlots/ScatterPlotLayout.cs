using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Events;

namespace DataExplorer.Domain.Views.ScatterPlots
{
    public class ScatterPlotLayout
    {
        private Column _xAxisColumn;
        private Column _yAxisColumn;

        public Column XAxisColumn
        {
            get { return _xAxisColumn; }
            set
            {
                _xAxisColumn = value;
                DomainEvents.Raise(new ScatterPlotLayoutColumnChangedEvent());
            }
        }

        public Column YAxisColumn
        {
            get { return _yAxisColumn; }
            set
            {
                _yAxisColumn = value;
                DomainEvents.Raise(new ScatterPlotLayoutColumnChangedEvent());
            }
        }

        public void Clear()
        {
            _xAxisColumn = null;
            _yAxisColumn = null;

            DomainEvents.Raise(new ScatterPlotLayoutColumnChangedEvent());
        }
    }
}
