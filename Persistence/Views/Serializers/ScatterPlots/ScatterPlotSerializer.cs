using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Xml.Linq;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Views.ScatterPlots;
using DataExplorer.Persistence.Projects;

namespace DataExplorer.Persistence.Views.Serializers.ScatterPlots
{
    public class ScatterPlotSerializer : IScatterPlotSerializer
    {
        private const string ScatterPlotTag = "scatter-plot";
        private const string LayoutTag = "layout";
        private const string ExtentTag = "extent";

        private readonly IScatterPlotLayoutSerializer _layoutSerializer;
        private readonly IPropertySerializer _propertySerializer;

        public ScatterPlotSerializer(
            IPropertySerializer propertySerializer, 
            IScatterPlotLayoutSerializer layoutSerializer)
        {
            _propertySerializer = propertySerializer;
            _layoutSerializer = layoutSerializer;
        }

        public XElement Serialize(ScatterPlot scatterPlot)
        {
            var xLayout = _layoutSerializer.Serialize(scatterPlot.GetLayout());

            var xExtent = _propertySerializer.Serialize(ExtentTag, scatterPlot.GetViewExtent());

            return new XElement(ScatterPlotTag, xLayout, xExtent);
        }

        public ScatterPlot Deserialize(XElement xView, IEnumerable<Column> columns)
        {
            var xLayout = xView.Elements().First(p => p.Name.LocalName == LayoutTag);

            var layout = _layoutSerializer.Deserialize(xLayout, columns);

            var xExtent = xView.Elements().First(p => p.Name.LocalName == ExtentTag);

            var extent = _propertySerializer.Deserialize<Rect>(xExtent);

            return new ScatterPlot(layout, extent, new List<Plot>());
        }
    }
}
