using DataExplorer.Domain.Colors;
using DataExplorer.Domain.Columns;

namespace DataExplorer.Domain.Views.ScatterPlots
{
    public class ScatterPlotLayout
    {
        private const double DefaultSize = 0.125d;

        private Column _xAxisColumn;
        private bool _xAxisReverse;
        private Column _yAxisColumn;
        private bool _yAxisReverse;
        private Column _colorColumn;
        private bool _colorReverse;
        private ColorPalette _colorPalette;
        private Column _sizeColumn;
        private bool _sizeReverse;
        private double _lowerSize;
        private double _upperSize;
        private Column _shapeColumn;
        private Column _labelColumn;
        private Column _linkColumn;

        public ScatterPlotLayout()
        {
            _lowerSize = DefaultSize;
            _upperSize = DefaultSize;
        }

        public Column XAxisColumn
        {
            get { return _xAxisColumn; }
            set { _xAxisColumn = value; }
        }

        public bool XAxisReverse
        {
            get { return _xAxisReverse; }
            set { _xAxisReverse = value; }
        }

        public Column YAxisColumn
        {
            get { return _yAxisColumn; }
            set { _yAxisColumn = value; }
        }

        public bool YAxisReverse
        {
            get { return _yAxisReverse; }
            set { _yAxisReverse = value; }
        }

        public Column ColorColumn
        {
            get { return _colorColumn; }
            set { _colorColumn = value; }
        }

        public bool ColorReverse
        {
            get { return _colorReverse; }
            set { _colorReverse = value; }
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

        public bool SizeReverse
        {
            get { return _sizeReverse; }
            set { _sizeReverse = value; }
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

        public Column ShapeColumn
        {
            get { return _shapeColumn; }
            set { _shapeColumn = value; }
        }

        public Column LabelColumn
        {
            get { return _labelColumn; }
            set { _labelColumn = value; }
        }

        public Column LinkColumn
        {
            get { return _linkColumn; }
            set { _linkColumn = value; }
        }

        public void Clear()
        {
            _xAxisColumn = null;
            _xAxisReverse = false;
            _yAxisColumn = null;
            _yAxisReverse = false;
            _colorColumn = null;
            _colorReverse = false;
            _colorPalette = new ColorPaletteFactory().Pastel1;
            _sizeColumn = null;
            _sizeReverse = false;
            _lowerSize = DefaultSize;
            _upperSize = DefaultSize;
            _shapeColumn = null;
            _labelColumn = null;
            _linkColumn = null;
        }
    }
}
