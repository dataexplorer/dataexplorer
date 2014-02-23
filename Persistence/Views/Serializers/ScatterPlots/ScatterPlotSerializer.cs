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
    public class ScatterPlotSerializer 
        : BaseSerializer,
        IScatterPlotSerializer
    {
        private const string ScatterPlotTag = "scatter-plot";
        private const string LayoutTag = "layout";
        private const string ExtentTag = "extent";

        private readonly IScatterPlotLayoutSerializer _layoutSerializer;

        public ScatterPlotSerializer(
            IPropertySerializer propertySerializer,
            IScatterPlotLayoutSerializer layoutSerializer) 
            : base(propertySerializer)
        {
            _layoutSerializer = layoutSerializer;
        }

        public XElement Serialize(ScatterPlot scatterPlot)
        {
            var xScatterPlot = new XElement(ScatterPlotTag);

            AddProperty(xScatterPlot, ExtentTag, scatterPlot.GetViewExtent());

            var xLayout = _layoutSerializer.Serialize(scatterPlot.GetLayout());

            xScatterPlot.Add(xLayout);

            return xScatterPlot;
        }

        public ScatterPlot Deserialize(XElement xView, List<Column> columns)
        {
            var xLayout = xView.Elements().First(p => p.Name.LocalName == LayoutTag);

            var layout = _layoutSerializer.Deserialize(xLayout, columns);

            var extent = GetProperty<Rect>(xView, ExtentTag);

            return new ScatterPlot(layout, extent, new List<Plot>());
        }
    }
}
