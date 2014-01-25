using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Core.Events;
using DataExplorer.Domain.Views.ScatterPlots.Events;

namespace DataExplorer.Domain.Views.ScatterPlots
{
    public class ScatterPlotLayout
    {
        private Column _xAxisColumn;
        private Column _yAxisColumn;
        private Column _colorColumn;
        private ColorPalette _colorPalette;

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

        public Column ColorColumn
        {
            get { return _colorColumn; }
            set
            {
                _colorColumn = value;
                DomainEvents.Raise(new ScatterPlotLayoutColumnChangedEvent());
            }
        }

        public ColorPalette ColorPalette
        {
            get { return _colorPalette; }
            set
            {
                _colorPalette = value;
                DomainEvents.Raise(new ScatterPlotLayoutColumnChangedEvent());
            }
        }

        public void Clear()
        {
            _xAxisColumn = null;
            _yAxisColumn = null;
            _colorColumn = null;
            _colorPalette = null;

            DomainEvents.Raise(new ScatterPlotLayoutColumnChangedEvent());
        }
    }
}
