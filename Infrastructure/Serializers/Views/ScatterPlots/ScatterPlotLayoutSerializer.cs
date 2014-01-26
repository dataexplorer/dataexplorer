using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DataExplorer.Domain.Colors;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Views.ScatterPlots;
using DataExplorer.Infrastructure.Serializers.Properties;

namespace DataExplorer.Infrastructure.Serializers.Views.ScatterPlots
{
    public class ScatterPlotLayoutSerializer : IScatterPlotLayoutSerializer
    {
        private const string LayoutTag = "layout";
        private const string XAxisColumnIdTag = "x-axis-column-id";
        private const string YAxisColumnIdTag = "y-axis-column-id";
        private const string ColorColumnIdTag = "color-column-id";
        private const string ColorPaletteNameTag = "color-palette-name";

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
            var xAxisColumnId = DeserializeProperty<int?>(xLayout, XAxisColumnIdTag);

            var xAxisColumn = GetColumn(columns, xAxisColumnId);

            var yAxisColumnId = DeserializeProperty<int?>(xLayout, YAxisColumnIdTag);

            var yAxisColumn = GetColumn(columns, yAxisColumnId);

            var colorColumnId = DeserializeProperty<int?>(xLayout, ColorColumnIdTag);

            var colorColumn = GetColumn(columns, colorColumnId);

            var colorPaletteName = DeserializeProperty<string>(xLayout, ColorPaletteNameTag);

            var colorPalette = _colorPaletteFactory.GetColorPalette(colorPaletteName);

            var layout = new ScatterPlotLayout()
            {
                XAxisColumn = xAxisColumn, 
                YAxisColumn = yAxisColumn,
                ColorColumn = colorColumn,
                ColorPalette = colorPalette
            };

            return layout;
        }

        private Column GetColumn(IEnumerable<Column> columns, int? xAxisColumnId)
        {
            return xAxisColumnId != null 
                ? columns.First(p => p.Id == xAxisColumnId) 
                : null;
        }

        private T DeserializeProperty<T>(XElement parent, string name)
        {
            var xProperty = parent.Elements().First(p => p.Name.LocalName == name);

            var property = _propertySerializer.Deserialize<T>(xProperty);

            return property;
        }
    }
}
