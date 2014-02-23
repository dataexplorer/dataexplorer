using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using DataExplorer.Domain.Colors;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Views.ScatterPlots;
using DataExplorer.Persistence.Projects;

namespace DataExplorer.Persistence.Views.Serializers.ScatterPlots
{
    public class ScatterPlotLayoutSerializer : IScatterPlotLayoutSerializer
    {
        private const string LayoutTag = "layout";
        private const string XAxisColumnIdTag = "x-axis-column-id";
        private const string YAxisColumnIdTag = "y-axis-column-id";
        private const string ColorColumnIdTag = "color-column-id";
        private const string ColorPaletteNameTag = "color-palette-name";
        private const string SizeColumnIdTag = "size-column-id";
        private const string LowerSizeTag = "lower-size";
        private const string UpperSizeTag = "upper-size";

        private readonly IPropertySerializer _propertySerializer;
        private readonly IColorPaletteFactory _colorPaletteFactory;

        public ScatterPlotLayoutSerializer(
            IPropertySerializer propertySerializer,
            IColorPaletteFactory colorPaletteFactory)
        {
            _propertySerializer = propertySerializer;
            _colorPaletteFactory = colorPaletteFactory;
        }

        public XElement Serialize(ScatterPlotLayout layout)
        {
            var xLayout = new XElement(LayoutTag);

            AddProperty(xLayout, XAxisColumnIdTag, GetColumnId(layout.XAxisColumn));

            AddProperty(xLayout, YAxisColumnIdTag, GetColumnId(layout.YAxisColumn));

            AddProperty(xLayout, ColorColumnIdTag, GetColumnId(layout.ColorColumn));

            AddProperty(xLayout, ColorPaletteNameTag, layout.ColorPalette.Name);

            AddProperty(xLayout, SizeColumnIdTag, GetColumnId(layout.SizeColumn));

            AddProperty(xLayout, LowerSizeTag, layout.LowerSize);

            AddProperty(xLayout, UpperSizeTag, layout.UpperSize);

            return xLayout;
        }

        private int? GetColumnId(Column column)
        {
            return (column == null) 
                ? (int?) null 
                : column.Id;
        }

        private void AddProperty<T>(XElement parent, string name, T value)
        {
            var xProperty = _propertySerializer.Serialize(name, value);

            parent.Add(xProperty);
        }

        public ScatterPlotLayout Deserialize(XElement xLayout, IEnumerable<Column> columns)
        {
            var xAxisColumn = DeserializeColumn(xLayout, XAxisColumnIdTag, columns);

            var yAxisColumn = DeserializeColumn(xLayout, YAxisColumnIdTag, columns);

            var colorColumn = DeserializeColumn(xLayout, ColorColumnIdTag, columns);

            var colorPaletteName = DeserializeProperty<string>(xLayout, ColorPaletteNameTag);

            var colorPalette = _colorPaletteFactory.GetColorPalette(colorPaletteName);

            var sizeColumn = DeserializeColumn(xLayout, SizeColumnIdTag, columns);

            var lowerSize = DeserializeProperty<double>(xLayout, LowerSizeTag);

            var upperSize = DeserializeProperty<double>(xLayout, UpperSizeTag);

            var layout = new ScatterPlotLayout()
            {
                XAxisColumn = xAxisColumn, 
                YAxisColumn = yAxisColumn,
                ColorColumn = colorColumn,
                ColorPalette = colorPalette,
                SizeColumn = sizeColumn,
                LowerSize = lowerSize,
                UpperSize = upperSize
            };

            return layout;
        }

        private Column DeserializeColumn(XElement parent, string name, IEnumerable<Column> columns)
        {
            var columnId = DeserializeProperty<int?>(parent, name);

            var column = columnId != null 
                ? columns.First(p => p.Id == columnId) 
                : null;

            return column;
        }

        private T DeserializeProperty<T>(XElement parent, string name)
        {
            var xProperty = parent.Elements().First(p => p.Name.LocalName == name);

            var property = _propertySerializer.Deserialize<T>(xProperty);

            return property;
        }
    }
}
