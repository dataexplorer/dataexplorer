using DataExplorer.Domain.Colors;
using DataExplorer.Domain.Columns;

namespace DataExplorer.Domain.Views.ScatterPlots
{
    public class ScatterPlotLayout
    {
        private Column _xAxisColumn;
        private Column _yAxisColumn;
        private Column _colorColumn;
        private ColorPalette _colorPalette;
        private Column _sizeColumn;
        private double _lowerSize;
        private double _upperSize;

        public Column XAxisColumn
        {
            get { return _xAxisColumn; }
            set { _xAxisColumn = value; }
        }

        public Column YAxisColumn
        {
            get { return _yAxisColumn; }
            set { _yAxisColumn = value; }
        }

        public Column ColorColumn
        {
            get { return _colorColumn; }
            set { _colorColumn = value; }
        }

        public ColorPalette ColorPalette
        {
            get { return _colorPalette; }
            set { _colorPalette = value; }
        }

        public Column SizeColumn
        {
            get { return _sizeColumn; } 
            set { _sizeColumn = value; }
        }

        public double LowerSize
        {
            get { return _lowerSize; }
            set { _lowerSize = value; }
        }

        public double UpperSize
        {
            get { return _upperSize; }
            set { _upperSize = value; }
        }

        public void Clear()
        {
            _xAxisColumn = null;
            _yAxisColumn = null;
            _colorColumn = null;
            _colorPalette = null;
            _sizeColumn = null;
            _lowerSize = 0d; // TODO: Need to decide on a default
            _upperSize = 1d; // TODO: Need to decide on a default
        }
    }
}
