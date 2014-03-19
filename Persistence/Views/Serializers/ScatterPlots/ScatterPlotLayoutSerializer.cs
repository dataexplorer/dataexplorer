using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using DataExplorer.Domain.Colors;
using DataExplorer.Domain.Columns;
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
        private const string YAxisColumnIdTag = "y-axis-column-id";
        private const string ColorColumnIdTag = "color-column-id";
        private const string ColorPaletteNameTag = "color-palette-name";
        private const string SizeColumnIdTag = "size-column-id";
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

            AddColumn(xLayout, YAxisColumnIdTag, layout.YAxisColumn);

            AddColumn(xLayout, ColorColumnIdTag, layout.ColorColumn);

            AddProperty(xLayout, ColorPaletteNameTag, layout.ColorPalette.Name);

            AddColumn(xLayout, SizeColumnIdTag, layout.SizeColumn);

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

            var yAxisColumn = GetColumn(xLayout, YAxisColumnIdTag, columns);

            var colorColumn = GetColumn(xLayout, ColorColumnIdTag, columns);

            var colorPaletteName = GetProperty<string>(xLayout, ColorPaletteNameTag);

            var colorPalette = _colorPaletteFactory.GetColorPalette(colorPaletteName);

            var sizeColumn = GetColumn(xLayout, SizeColumnIdTag, columns);

            var lowerSize = GetProperty<double>(xLayout, LowerSizeTag);

            var upperSize = GetProperty<double>(xLayout, UpperSizeTag);

            var shapeColumn = GetColumn(xLayout, ShapeColumnIdTag, columns);
            
            var labelColumn = GetColumn(xLayout, LabelColumnIdTag, columns);

            var linkColumn = GetColumn(xLayout, LinkColumnIdTag, columns);

            var layout = new ScatterPlotLayout()
            {
                XAxisColumn = xAxisColumn, 
                YAxisColumn = yAxisColumn,
                ColorColumn = colorColumn,
                ColorPalette = colorPalette,
                SizeColumn = sizeColumn,
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
