using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Media;

namespace DataExplorer.Presentation.Panes.Legend.Sizes
{
    public class SizeLegend : BaseLegend
    {
        public static readonly DependencyProperty ItemsProperty = DependencyProperty.Register(
           "Items",
           typeof(List<SizeLegendItemViewModel>),
           typeof(SizeLegend),
           new PropertyMetadata(OnItemsChanged));

        public List<SizeLegendItemViewModel> Items
        {
            get { return (List<SizeLegendItemViewModel>)GetValue(ItemsProperty); }
            set { SetValue(ItemsProperty, value); }
        }

        protected override void RenderItems()
        {
            base.PreRenderItems();

            var items = GetValue(ItemsProperty) as List<SizeLegendItemViewModel>;

            if (items == null || !items.Any())
            {
                Height = 0;
                return;
            }

            Height = items.Count * 20 + 16 + 8;

            var x = 64d;

            var originY = 32d;

            var pen = new Pen(Brushes.Black, 1);

            var brush = Brushes.LightGray;

            for (int i = 0; i < items.Count; i++)
            {
                var item = items[i];

                double y = originY + i * 20;
                
                double radius = (item.Size / 2) * 256;

                RenderItem(x, y, radius, pen, brush);

                RenderLabel(128, y, item.Label);
            }

            base.PostRenderItems();
        }

        private void RenderItem(double x, double y, double radius, Pen pen, SolidColorBrush brush)
        {
            var visual = new DrawingVisual();

            using (var context = visual.RenderOpen())
            {
                context.PushClip(new RectangleGeometry(new Rect(0, y - 8, 128, 16)));

                context.DrawEllipse(brush, pen, new Point(x, y), radius, radius);
            }

            _visuals.Add(visual);
        }
    }
}
