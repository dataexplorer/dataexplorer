using System;
using System.Collections.Generic;
using System.Xml.Linq;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Views;

namespace DataExplorer.Persistence.Views.Serializers
{
    public class ViewSetSerializer : IViewSetSerializer
    {
        private static readonly string ViewsTag = "views";

        private readonly IViewSerializer _viewSerializer;

        public ViewSetSerializer(IViewSerializer viewSerializer)
        {
            _viewSerializer = viewSerializer;
        }

        public XElement Serialize(IEnumerable<View> views)
        {
            var xViews = new XElement(ViewsTag);

            foreach (var view in views)
            {
                var xSource = _viewSerializer.Serialize(view);

                xViews.Add(xSource);
            }

            return xViews;
        }

        public IEnumerable<View> Deserialize(XElement xViews, List<Column> columns)
        {
            var views = new List<View>();

            foreach (var xView in xViews.Elements())
            {
                var view = _viewSerializer.Deserialize(xView, columns);

                views.Add(view);
            }

            return views;
        }
    }
}
