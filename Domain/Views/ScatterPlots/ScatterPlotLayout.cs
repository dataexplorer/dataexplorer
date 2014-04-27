using DataExplorer.Domain.Colors;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Layouts;

namespace DataExplorer.Domain.Views.ScatterPlots
{
    public class ScatterPlotLayout
    {
        private const SortOrder DefaultSortOrder = SortOrder.Ascending;
        private const double DefaultSize = 0.125d;

        private Column _xAxisColumn;
        private SortOrder _xAxisSortOrder;
        private Column _yAxisColumn;
        private SortOrder _yAxisSortOrder;
        private Column _colorColumn;
        private SortOrder _colorSortOrder;
        private ColorPalette _colorPalette;
        private Column _sizeColumn;
        private SortOrder _sizeSortOrder;
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

        public SortOrder XAxisSortOrder
        {
            get { return _xAxisSortOrder; }
            set { _xAxisSortOrder = value; }
        }

        public Column YAxisColumn
        {
            get { return _yAxisColumn; }
            set { _yAxisColumn = value; }
        }

        public SortOrder YAxisSortOrder
        {
            get { return _yAxisSortOrder; }
            set { _yAxisSortOrder = value; }
        }

        public Column ColorColumn
        {
            get { return _colorColumn; }
            set { _colorColumn = value; }
        }

        public SortOrder ColorSortOrder
        {
            get { return _colorSortOrder; }
            set { _colorSortOrder = value; }
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

        public SortOrder SizeSortOrder
        {
            get { return _sizeSortOrder; }
            set { _sizeSortOrder = value; }
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
            _xAxisSortOrder = DefaultSortOrder;
            _yAxisColumn = null;
            _yAxisSortOrder = DefaultSortOrder;
            _colorColumn = null;
            _colorSortOrder = DefaultSortOrder;
            _colorPalette = new ColorPaletteFactory().Pastel1;
            _sizeColumn = null;
            _sizeSortOrder = DefaultSortOrder;
            _lowerSize = DefaultSize;
            _upperSize = DefaultSize;
            _shapeColumn = null;
            _labelColumn = null;
            _linkColumn = null;
        }
    }
}
