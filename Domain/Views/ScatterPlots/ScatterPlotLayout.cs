using DataExplorer.Domain.Columns;

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

        public void Clear()
        {
            _xAxisColumn = null;
            _yAxisColumn = null;
            _colorColumn = null;
            _colorPalette = null;
        }
    }
}
