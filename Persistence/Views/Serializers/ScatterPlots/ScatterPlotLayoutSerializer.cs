using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using DataExplorer.Domain.Colors;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Layouts;
using DataExplorer.Domain.Views.ScatterPlots;
using DataExplorer.Persistence.Common.Serializers;
using DataExplorer.Persistence.Projects;

namespace DataExplorer.Persistence.Views.Serializers.ScatterPlots
{
    public class ScatterPlotLayoutSerializer 
        : BaseSerializer,
        IScatterPlotLayoutSerializer
    {
        private const string LayoutTag = "layout";
        private const string XAxisColumnIdTag = "x-axis-column-id";
        private const string XAxisReverseTag = "x-axis-sort-order";
        private const string YAxisColumnIdTag = "y-axis-column-id";
        private const string YAxisReverseTag = "y-axis-sort-order";
        private const string ColorColumnIdTag = "color-column-id";
        private const string ColorReverseTag = "color-sort-order";
        private const string ColorPaletteNameTag = "color-palette-name";
        private const string SizeColumnIdTag = "size-column-id";
        private const string SizeReverseTag = "size-sort-order";
        private const string LowerSizeTag = "lower-size";
        private const string UpperSizeTag = "upper-size";
        private const string ShapeColumnIdTag = "shape-column-id";
        private const string LabelColumnIdTag = "label-column-id";
        private const string LinkColumnIdTag = "link-column-id";

        private readonly IColorPaletteFactory _colorPaletteFactory;

        public ScatterPlotLayoutSerializer(
            IPropertySerializer propertySerializer,
            IColorPaletteFactory colorPaletteFactory) 
            : base(propertySerializer)
        {
            _colorPaletteFactory = colorPaletteFactory;
        }

        public XElement Serialize(ScatterPlotLayout layout)
        {
            var xLayout = new XElement(LayoutTag);

            AddColumn(xLayout, XAxisColumnIdTag, layout.XAxisColumn);

            AddProperty(xLayout, XAxisReverseTag, layout.XAxisSortOrder);

            AddColumn(xLayout, YAxisColumnIdTag, layout.YAxisColumn);

            AddProperty(xLayout, YAxisReverseTag, layout.YAxisSortOrder);

            AddColumn(xLayout, ColorColumnIdTag, layout.ColorColumn);

            AddProperty(xLayout, ColorReverseTag, layout.ColorSortOrder);

            AddProperty(xLayout, ColorPaletteNameTag, layout.ColorPalette.Name);

            AddColumn(xLayout, SizeColumnIdTag, layout.SizeColumn);

            AddProperty(xLayout, SizeReverseTag, layout.SizeSortOrder);

            AddProperty(xLayout, LowerSizeTag, layout.LowerSize);

            AddProperty(xLayout, UpperSizeTag, layout.UpperSize);

            AddColumn(xLayout, ShapeColumnIdTag, layout.ShapeColumn);

            AddColumn(xLayout, LabelColumnIdTag, layout.LabelColumn);

            AddColumn(xLayout, LinkColumnIdTag, layout.LinkColumn);

            return xLayout;
        }
        
        public ScatterPlotLayout Deserialize(XElement xLayout, List<Column> columns)
        {
            var xAxisColumn = GetColumn(xLayout, XAxisColumnIdTag, columns);

            var xAxisReverse = GetProperty<SortOrder>(xLayout, XAxisReverseTag);

            var yAxisColumn = GetColumn(xLayout, YAxisColumnIdTag, columns);

            var yAxisReverse = GetProperty<SortOrder>(xLayout, YAxisReverseTag);
            
            var colorColumn = GetColumn(xLayout, ColorColumnIdTag, columns);

            var colorReverse = GetProperty<SortOrder>(xLayout, ColorReverseTag);

            var colorPaletteName = GetProperty<string>(xLayout, ColorPaletteNameTag);

            var colorPalette = _colorPaletteFactory.GetColorPalette(colorPaletteName);

            var sizeColumn = GetColumn(xLayout, SizeColumnIdTag, columns);

            var sizeReverse = GetProperty<SortOrder>(xLayout, SizeReverseTag);

            var lowerSize = GetProperty<double>(xLayout, LowerSizeTag);

            var upperSize = GetProperty<double>(xLayout, UpperSizeTag);

            var shapeColumn = GetColumn(xLayout, ShapeColumnIdTag, columns);
            
            var labelColumn = GetColumn(xLayout, LabelColumnIdTag, columns);

            var linkColumn = GetColumn(xLayout, LinkColumnIdTag, columns);

            var layout = new ScatterPlotLayout()
            {
                XAxisColumn = xAxisColumn,
                XAxisSortOrder = xAxisReverse,
                YAxisColumn = yAxisColumn,
                YAxisSortOrder =  yAxisReverse,
                ColorColumn = colorColumn,
                ColorSortOrder = colorReverse,
                ColorPalette = colorPalette,
                SizeColumn = sizeColumn,
                SizeSortOrder = sizeReverse,
                LowerSize = lowerSize,
                UpperSize = upperSize,
                ShapeColumn = shapeColumn,
                LabelColumn = labelColumn,
                LinkColumn = linkColumn
            };

            return layout;
        }
    }
}
