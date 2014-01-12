using System;
using System.Collections.Generic;
using System.Xml.Linq;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Views;
using DataExplorer.Domain.Views.ScatterPlots;
using DataExplorer.Infrastructure.Serializers.Views.ScatterPlots;

namespace DataExplorer.Infrastructure.Serializers.Views
{
    public class ViewSerializer : IViewSerializer
    {
        private readonly IScatterPlotSerializer _scatterPlotSerializer;

        public ViewSerializer(IScatterPlotSerializer scatterPlotSerializer)
        {
            _scatterPlotSerializer = scatterPlotSerializer;
        }

        public XElement Serialize(IView view)
        {
            if (view is ScatterPlot)
                return _scatterPlotSerializer.Serialize((ScatterPlot) view);

            throw new ArgumentException("View cannot be serialized because view is not recognized.");
        }

        public IView Deserialize(XElement xView, IEnumerable<Column> columns)
        {
            if (xView.Name.LocalName == "scatter-plot")
                return _scatterPlotSerializer.Deserialize(xView, columns);

            throw new ArgumentException("View cannot be deserialized because view is not recognized.");
        }
    }
}
