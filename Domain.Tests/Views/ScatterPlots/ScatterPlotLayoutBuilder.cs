using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Colors;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Layouts;
using DataExplorer.Domain.Views.ScatterPlots;

namespace DataExplorer.Domain.Tests.Views.ScatterPlots
{
    public class ScatterPlotLayoutBuilder
    {
        private readonly ScatterPlotLayout _layout;

        public ScatterPlotLayoutBuilder()
        {
            _layout = new ScatterPlotLayout();    
        }

        public ScatterPlotLayoutBuilder WithXAxisColumn(Column column)
        {
            _layout.XAxisColumn = column;
            return this;
        }

        public ScatterPlotLayoutBuilder WithXAxisSortOrder(SortOrder sortOrder)
        {
            _layout.XAxisSortOrder = sortOrder;
            return this;
        }

        public ScatterPlotLayoutBuilder WithYAxisColumn(Column column)
        {
            _layout.YAxisColumn = column;
            return this;
        }

        public ScatterPlotLayoutBuilder WithYAxisSortOrder(SortOrder sortOrder)
        {
            _layout.YAxisSortOrder = sortOrder;
            return this;
        }

        public ScatterPlotLayoutBuilder WithColorColumn(Column column)
        {
            _layout.ColorColumn = column;
            return this;
        }

        public ScatterPlotLayoutBuilder WithColorSortOrder(SortOrder sortOrder)
        {
            _layout.ColorSortOrder = sortOrder;
            return this;
        }

        public ScatterPlotLayoutBuilder WithColorPalette(ColorPalette colorPalette)
        {
            _layout.ColorPalette = colorPalette;
            return this;
        }

        public ScatterPlotLayoutBuilder WithSizeColumn(Column column)
        {
            _layout.SizeColumn = column;
            return this;
        }

        public ScatterPlotLayoutBuilder WithSizeSortOrder(SortOrder sortOrder)
        {
            _layout.SizeSortOrder = sortOrder;
            return this;
        }

        public ScatterPlotLayoutBuilder WithLowerSize(double size)
        {
            _layout.LowerSize = size;
            return this;
        }

        public ScatterPlotLayoutBuilder WithUpperSize(double size)
        {
            _layout.UpperSize = size;
            return this;
        }

        public ScatterPlotLayoutBuilder WithLabelColumn(Column column)
        {
            _layout.LabelColumn = column;
            return this;
        }

        public ScatterPlotLayoutBuilder WithLinkColumn(Column column)
        {
            _layout.LinkColumn = column;
            return this;
        }

        public ScatterPlotLayout Build()
        {
            return _layout;
        }
    }
}
